using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using EnvDTE;
using EnvDTE80;
using System.Collections.Generic;
using System.Windows.Forms;
using VSLangProj;
using System.Collections;

namespace ActualizadorVersion
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class commandActualizador
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("58bc734d-5928-426d-bb8b-540b9feeb2b6");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="commandActualizador"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private commandActualizador(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static commandActualizador Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in commandActualizador's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new commandActualizador(package, commandService);
        }

        string Cambios = string.Empty;
        string NewVersion = string.Empty;

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            try
            {
                frmVersion frm = new frmVersion(NewVersion);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    //string NewVersion = "2.0.3";
                    NewVersion = frm.version;
                    Hashtable mapHierarchies = new Hashtable();
                    Cambios = string.Empty;
                    DTE2 dte2 = Package.GetGlobalService(typeof(DTE)) as DTE2;
                    var sol = dte2.Solution;
                    //var projs = sol.Projects;
                    Projects projs = sol.Projects;

                    AddMessage($"Solucion => {sol.FullName} ({projs.Count})");
                    RecursivaProjectos(projs);

                    ThreadHelper.ThrowIfNotOnUIThread();
                    //string messageT = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
                    string titleT = $"Actualizada la version a {NewVersion}";
                    // Show a message box to prove we were here
                    VsShellUtilities.ShowMessageBox(
                        this.package,
                        Cambios,
                        titleT,
                        OLEMSGICON.OLEMSGICON_INFO,
                        OLEMSGBUTTON.OLEMSGBUTTON_OK,
                        OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
                }
            }
            catch (Exception ex)
            {
                string titleT = $"ERROR al Actualizada la version";
                // Show a message box to prove we were here
                VsShellUtilities.ShowMessageBox(
                    this.package,
                    ex.ToString(),
                    titleT,
                    OLEMSGICON.OLEMSGICON_INFO,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }
        }

        private void RecursivaProjectos(IEnumerable projs)
        {
            foreach (var proj in projs)
            {
                var project = proj as Project;
                if (project.Kind == ProjectKinds.vsProjectKindSolutionFolder)
                {
                    AddMessage($"Carpeta => {project.Name} ");
                    var projInFolders = project.ProjectItems;

                    var innerProjects = GetSolutionFolderProjects(project);
                    RecursivaProjectos(innerProjects);
                }
                else //if (project.Kind == PrjKind.prjKindCSharpProject)
                {
                    AddMessage($"Projecto => {project.Name} ");
                    if (project.Properties != null)
                    {
                        foreach (Property property in project.Properties)
                        {
                            string name = property.Name;
                            if (property.Value != null && property.Name == "Version")
                            {
                                string version_OLD = property.Value.ToString();
                                property.Value = NewVersion;
                                string version_NEW = property.Value.ToString();
                                AddMessage($"Version {version_OLD} => {version_NEW}");
                            }
                        }
                    }
                }
            }
        }

        private static IEnumerable<Project> GetSolutionFolderProjects(Project project)
        {
            List<Project> projects = new List<Project>();
            var y = (project.ProjectItems as ProjectItems).Count;
            for (var i = 1; i <= y; i++)
            {
                var x = project.ProjectItems.Item(i).SubProject;
                var subProject = x as Project;
                if (subProject != null)
                {
                    projects.Add(subProject);
                    //Carried out work and added projects as appropriate
                }
            }

            return projects;
        }

        private void AddMessage(string message)
        {
            Cambios = $"{Cambios}{message} {Environment.NewLine}";
        }
    }
}
