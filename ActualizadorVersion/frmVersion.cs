using EnvDTE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ActualizadorVersion
{
    public partial class frmVersion : Form
    {
        public string version = string.Empty;
        public bool ActualizarTodos => chkActualizarTodosProyectos.Checked;
        public List<ItemProject> projectosActualizar;

        private ItemProject solucion;
        public frmVersion()
        {
            InitializeComponent();
        }
        public frmVersion(string versionAnteriorUsada) : this()
        {
            txtVersion.Text = versionAnteriorUsada;
        }
        public frmVersion(string versionAnteriorUsada, ItemProject solucion) : this(versionAnteriorUsada)
        {
            this.solucion = solucion;
        }

        private void frmVersion_Load(object sender, EventArgs e)
        {
            LoadUI();
        }

        private void LoadUI()
        {
            lblError.Visible = false;

            ControlarCollapsePanel2();
            tProyectos.CheckBoxes = true;

            // Add nodes to treeView1.
            //TreeNode node;
            //for (int x = 0; x < 3; ++x)
            //{
            //    // Add a root node.
            //    node = tProyectos.Nodes.Add(String.Format("Node{0}", x * 4), String.Format("Node{0}", x * 4),0,0);
            //    for (int y = 1; y < 4; ++y)
            //    {
            //        // Add a node as a child of the previously added node.
            //        node = node.Nodes.Add(String.Format("Node{0}", x * 4 + y), String.Format("Node{0}", x * 4 + y),1,1);
            //    }
            //}

            if (solucion == null || !solucion.ItemProjectosHijo.Any())
            {
                chkActualizarTodosProyectos.Visible = false;
            }
            else
            {
                TreeNode node = new TreeNode($"{solucion.Name}", 0, 0);
                node.Tag = solucion;
                node = AddProyectosTree(solucion.ItemProjectosHijo, node);
                tProyectos.Nodes.Add(node);
            }
            tProyectos.ExpandAll();
        }


        private TreeNode AddProyectosTree(List<ItemProject> projects, TreeNode node)
        {
            TreeNode nodeAux;
            foreach (ItemProject project in projects)
            {
                nodeAux = new TreeNode($"{project.Name}", project.IsFolder ? 0 : 1, project.IsFolder ? 0 : 1);
                nodeAux.Tag = project;
                if (project.IsFolder)
                {
                    nodeAux = AddProyectosTree(project.ItemProjectosHijo, nodeAux);
                }
                node.Nodes.Add(nodeAux);
            }
            return node;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            RecuperarProyectosSeleccionados(tProyectos.Nodes);
            ValidarNumeroVersion();
        }


        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtVersion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ValidarNumeroVersion();
            }
        }

        private void ValidarNumeroVersion()
        {
            lblError.Visible = false;
            bool valido = RegexValidarNumeroVersion(txtVersion.Text);
            if (valido)
            {
                version = txtVersion.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Visible = true;
            }
        }

        private bool RegexValidarNumeroVersion(string version)
        {
            if (!string.IsNullOrEmpty(version))
            {
                return System.Text.RegularExpressions.Regex.IsMatch(version, @"^\d+\.\d+\.\d+(\.\d+)?$");
            }
            return false;
        }

        private void chkActualizarTodosProyectos_CheckedChanged(object sender, EventArgs e)
        {
            ControlarCollapsePanel2();
        }

        private void ControlarCollapsePanel2()
        {
            scBase.Panel2Collapsed = chkActualizarTodosProyectos.Checked;
            this.Size = new Size(this.Size.Width, chkActualizarTodosProyectos.Checked ? 150 : 645);
        }

        private void tProyectos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                CheckCascade(e.Node, e.Node.Checked);
            }
        }

        private void CheckCascade(TreeNode node, bool check)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = check;
                if (child.Nodes.Count > 0)
                {
                    CheckCascade(child, check);
                }
            }
        }

        private void RecuperarProyectosSeleccionados(TreeNodeCollection nodes)
        {
            if (!ActualizarTodos)
            {
                if (projectosActualizar == null) projectosActualizar = new List<ItemProject>();
                foreach (TreeNode node in nodes)
                {
                    if (node.Checked) projectosActualizar.Add((ItemProject)node.Tag);
                    if (node.Nodes.Count > 0) RecuperarProyectosSeleccionados(node.Nodes);
                }
            }
        }
    }




}
