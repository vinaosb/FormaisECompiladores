
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	
	private global::Gtk.Action ArquivoAction;
	
	private global::Gtk.Action EditarAction;
	
	private global::Gtk.Action AbrirAction;
	
	private global::Gtk.Action SalvarAction;
	
	private global::Gtk.Action ArquivoAction1;
	
	private global::Gtk.Action EditarAction1;
	
	private global::Gtk.Action InserirAction;
	
	private global::Gtk.Action AutmatoAction;
	
	private global::Gtk.Action GramticaRegularAction;
	
	private global::Gtk.Action ExpressoRegularAction;
	
	private global::Gtk.Action AbrirAction1;
	
	private global::Gtk.Action AutomatoAction;
	
	private global::Gtk.Action SalvarAction1;
	
	private global::Gtk.Action AutomatoAction1;
	
	private global::Gtk.Action DeterminizarAutmatoAction;
	
	private global::Gtk.Action GramticaAction;
	
	private global::Gtk.Action GramaticaAction;
	
	private global::Gtk.Action UnirAutmatosAction;
	
	private global::Gtk.Action EditarAutmatoAction;
	
	private global::Gtk.Action EditarAutmatoAction1;
	
	private global::Gtk.Action InterseccionarAutmatosAction;
	
	private global::Gtk.Action MinimizarAutmatoAction;
	
	private global::Gtk.Action ConverterEREmAFDAction;
	
	private global::Gtk.Action GramticaRegularAction1;
	
	private global::Gtk.Action ExpressoAction;
	
	private global::Gtk.Action ExpressoAction1;
	
	private global::Gtk.Action ConverterGramticaParaAFNDAction;
	
	private global::Gtk.Action ConverterAFDEmGramticaAction;
	
	private global::Gtk.VBox vbox2;
	
	private global::Gtk.MenuBar menubar2;
	
	private global::Gtk.Notebook notebook1;
	
	private global::Gtk.VBox vbox3;
	
	private global::Gtk.ComboBox combobox1;
	
	private global::Gtk.ScrolledWindow scrolledwindow1;
	
	private global::Gtk.HButtonBox hbuttonbox2;
	
	private global::Gtk.Button button6;
	
	private global::Gtk.Label label2;
	
	private global::Gtk.VBox vbox4;
	
	private global::Gtk.ComboBox combobox2;
	
	private global::Gtk.ScrolledWindow scrolledwindow2;
	
	private global::Gtk.TextView textview2;
	
	private global::Gtk.HButtonBox hbuttonbox3;
	
	private global::Gtk.Button button230;
	
	private global::Gtk.Label label4;
	
	private global::Gtk.VBox vbox5;
	
	private global::Gtk.ComboBox combobox3;
	
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	
	private global::Gtk.TextView textview3;
	
	private global::Gtk.HButtonBox hbuttonbox4;
	
	private global::Gtk.Button button1952;
	
	private global::Gtk.Label label5;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.ArquivoAction = new global::Gtk.Action ("ArquivoAction", global::Mono.Unix.Catalog.GetString ("Arquivo"), null, null);
		this.ArquivoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Arquivo");
		w1.Add (this.ArquivoAction, null);
		this.EditarAction = new global::Gtk.Action ("EditarAction", global::Mono.Unix.Catalog.GetString ("Editar"), null, null);
		this.EditarAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Editar");
		w1.Add (this.EditarAction, null);
		this.AbrirAction = new global::Gtk.Action ("AbrirAction", global::Mono.Unix.Catalog.GetString ("Abrir"), null, null);
		this.AbrirAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Abrir");
		w1.Add (this.AbrirAction, null);
		this.SalvarAction = new global::Gtk.Action ("SalvarAction", global::Mono.Unix.Catalog.GetString ("Salvar"), null, null);
		this.SalvarAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Salvar");
		w1.Add (this.SalvarAction, null);
		this.ArquivoAction1 = new global::Gtk.Action ("ArquivoAction1", global::Mono.Unix.Catalog.GetString ("Arquivo"), null, null);
		this.ArquivoAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Arquivo");
		w1.Add (this.ArquivoAction1, null);
		this.EditarAction1 = new global::Gtk.Action ("EditarAction1", global::Mono.Unix.Catalog.GetString ("Editar"), null, null);
		this.EditarAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Editar");
		w1.Add (this.EditarAction1, null);
		this.InserirAction = new global::Gtk.Action ("InserirAction", global::Mono.Unix.Catalog.GetString ("Inserir"), null, null);
		this.InserirAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Inserir");
		w1.Add (this.InserirAction, null);
		this.AutmatoAction = new global::Gtk.Action ("AutmatoAction", global::Mono.Unix.Catalog.GetString ("Autômato"), null, null);
		this.AutmatoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Autômato");
		w1.Add (this.AutmatoAction, null);
		this.GramticaRegularAction = new global::Gtk.Action ("GramticaRegularAction", global::Mono.Unix.Catalog.GetString ("Gramática Regular"), null, null);
		this.GramticaRegularAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Gramática Regular");
		w1.Add (this.GramticaRegularAction, null);
		this.ExpressoRegularAction = new global::Gtk.Action ("ExpressoRegularAction", global::Mono.Unix.Catalog.GetString ("Expressão Regular"), null, null);
		this.ExpressoRegularAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Expressão Regular");
		w1.Add (this.ExpressoRegularAction, null);
		this.AbrirAction1 = new global::Gtk.Action ("AbrirAction1", global::Mono.Unix.Catalog.GetString ("Abrir"), null, null);
		this.AbrirAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Abrir");
		w1.Add (this.AbrirAction1, null);
		this.AutomatoAction = new global::Gtk.Action ("AutomatoAction", global::Mono.Unix.Catalog.GetString ("Automato"), null, null);
		this.AutomatoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Automato");
		w1.Add (this.AutomatoAction, null);
		this.SalvarAction1 = new global::Gtk.Action ("SalvarAction1", global::Mono.Unix.Catalog.GetString ("Salvar"), null, null);
		this.SalvarAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Salvar");
		w1.Add (this.SalvarAction1, null);
		this.AutomatoAction1 = new global::Gtk.Action ("AutomatoAction1", global::Mono.Unix.Catalog.GetString ("Automato"), null, null);
		this.AutomatoAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Automato");
		w1.Add (this.AutomatoAction1, null);
		this.DeterminizarAutmatoAction = new global::Gtk.Action ("DeterminizarAutmatoAction", global::Mono.Unix.Catalog.GetString ("Determinizar Autômato"), null, null);
		this.DeterminizarAutmatoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Determinizar Autômato");
		w1.Add (this.DeterminizarAutmatoAction, null);
		this.GramticaAction = new global::Gtk.Action ("GramticaAction", global::Mono.Unix.Catalog.GetString ("Gramática"), null, null);
		this.GramticaAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Gramática");
		w1.Add (this.GramticaAction, null);
		this.GramaticaAction = new global::Gtk.Action ("GramaticaAction", global::Mono.Unix.Catalog.GetString ("Gramatica"), null, null);
		this.GramaticaAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Gramatica");
		w1.Add (this.GramaticaAction, null);
		this.UnirAutmatosAction = new global::Gtk.Action ("UnirAutmatosAction", global::Mono.Unix.Catalog.GetString ("Unir Autômatos"), null, null);
		this.UnirAutmatosAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Unir Autômatos");
		w1.Add (this.UnirAutmatosAction, null);
		this.EditarAutmatoAction = new global::Gtk.Action ("EditarAutmatoAction", global::Mono.Unix.Catalog.GetString ("Editar Autômato"), null, null);
		this.EditarAutmatoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Editar Autômato");
		w1.Add (this.EditarAutmatoAction, null);
		this.EditarAutmatoAction1 = new global::Gtk.Action ("EditarAutmatoAction1", global::Mono.Unix.Catalog.GetString ("Editar Autômato"), null, null);
		this.EditarAutmatoAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Editar Autômato");
		w1.Add (this.EditarAutmatoAction1, null);
		this.InterseccionarAutmatosAction = new global::Gtk.Action ("InterseccionarAutmatosAction", global::Mono.Unix.Catalog.GetString ("Interseccionar Autômatos"), null, null);
		this.InterseccionarAutmatosAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Interseccionar Autômatos");
		w1.Add (this.InterseccionarAutmatosAction, null);
		this.MinimizarAutmatoAction = new global::Gtk.Action ("MinimizarAutmatoAction", global::Mono.Unix.Catalog.GetString ("Minimizar Autômato"), null, null);
		this.MinimizarAutmatoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Minimizar Autômato");
		w1.Add (this.MinimizarAutmatoAction, null);
		this.ConverterEREmAFDAction = new global::Gtk.Action ("ConverterEREmAFDAction", global::Mono.Unix.Catalog.GetString ("Converter ER em AFD"), null, null);
		this.ConverterEREmAFDAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Converter ER em AFD");
		w1.Add (this.ConverterEREmAFDAction, null);
		this.GramticaRegularAction1 = new global::Gtk.Action ("GramticaRegularAction1", global::Mono.Unix.Catalog.GetString ("Gramtica Regular"), null, null);
		this.GramticaRegularAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Gramtica Regular");
		w1.Add (this.GramticaRegularAction1, null);
		this.ExpressoAction = new global::Gtk.Action ("ExpressoAction", global::Mono.Unix.Catalog.GetString ("Expressão"), null, null);
		this.ExpressoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Expressão");
		w1.Add (this.ExpressoAction, null);
		this.ExpressoAction1 = new global::Gtk.Action ("ExpressoAction1", global::Mono.Unix.Catalog.GetString ("Expressão"), null, null);
		this.ExpressoAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Expressão");
		w1.Add (this.ExpressoAction1, null);
		this.ConverterGramticaParaAFNDAction = new global::Gtk.Action ("ConverterGramticaParaAFNDAction", global::Mono.Unix.Catalog.GetString ("Converter Gramática para AFND"), null, null);
		this.ConverterGramticaParaAFNDAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Converter Gramática para AFND");
		w1.Add (this.ConverterGramticaParaAFNDAction, null);
		this.ConverterAFDEmGramticaAction = new global::Gtk.Action ("ConverterAFDEmGramticaAction", global::Mono.Unix.Catalog.GetString ("Converter AFD em Gramática"), null, null);
		this.ConverterAFDEmGramticaAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Converter AFD em Gramática");
		w1.Add (this.ConverterAFDEmGramticaAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar2'><menu name='ArquivoAction1' action='ArquivoAction1'><menu name='AbrirAction1' action='AbrirAction1'><menuitem name='AutomatoAction' action='AutomatoAction'/><menuitem name='GramaticaAction' action='GramaticaAction'/><menuitem name='ExpressoAction1' action='ExpressoAction1'/></menu><menu name='SalvarAction1' action='SalvarAction1'><menuitem name='AutomatoAction1' action='AutomatoAction1'/><menuitem name='GramticaAction' action='GramticaAction'/><menuitem name='ExpressoAction' action='ExpressoAction'/></menu></menu><menu name='EditarAction1' action='EditarAction1'><menuitem name='DeterminizarAutmatoAction' action='DeterminizarAutmatoAction'/><menuitem name='UnirAutmatosAction' action='UnirAutmatosAction'/><menuitem name='InterseccionarAutmatosAction' action='InterseccionarAutmatosAction'/><menuitem name='MinimizarAutmatoAction' action='MinimizarAutmatoAction'/><menuitem name='ConverterEREmAFDAction' action='ConverterEREmAFDAction'/><menuitem name='ConverterGramticaParaAFNDAction' action='ConverterGramticaParaAFNDAction'/><menuitem name='ConverterAFDEmGramticaAction' action='ConverterAFDEmGramticaAction'/></menu><menu name='InserirAction' action='InserirAction'><menuitem name='AutmatoAction' action='AutmatoAction'/></menu></menubar></ui>");
		this.menubar2 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar2")));
		this.menubar2.Name = "menubar2";
		this.vbox2.Add (this.menubar2);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.menubar2]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.notebook1 = new global::Gtk.Notebook ();
		this.notebook1.CanFocus = true;
		this.notebook1.Name = "notebook1";
		this.notebook1.CurrentPage = 1;
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.vbox3 = new global::Gtk.VBox ();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.combobox1 = global::Gtk.ComboBox.NewText ();
		this.combobox1.Name = "combobox1";
		this.vbox3.Add (this.combobox1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.combobox1]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.scrolledwindow1 = new global::Gtk.ScrolledWindow ();
		this.scrolledwindow1.CanFocus = true;
		this.scrolledwindow1.Name = "scrolledwindow1";
		this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		this.vbox3.Add (this.scrolledwindow1);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.scrolledwindow1]));
		w4.Position = 1;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbuttonbox2 = new global::Gtk.HButtonBox ();
		this.hbuttonbox2.Name = "hbuttonbox2";
		// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
		this.button6 = new global::Gtk.Button ();
		this.button6.CanFocus = true;
		this.button6.Name = "button6";
		this.button6.UseUnderline = true;
		this.button6.Label = global::Mono.Unix.Catalog.GetString ("Adicionar Autômato");
		this.hbuttonbox2.Add (this.button6);
		global::Gtk.ButtonBox.ButtonBoxChild w5 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2 [this.button6]));
		w5.Expand = false;
		w5.Fill = false;
		this.vbox3.Add (this.hbuttonbox2);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbuttonbox2]));
		w6.Position = 2;
		w6.Expand = false;
		w6.Fill = false;
		this.notebook1.Add (this.vbox3);
		// Notebook tab
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Autômato");
		this.notebook1.SetTabLabel (this.vbox3, this.label2);
		this.label2.ShowAll ();
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.vbox4 = new global::Gtk.VBox ();
		this.vbox4.Name = "vbox4";
		this.vbox4.Spacing = 6;
		// Container child vbox4.Gtk.Box+BoxChild
		this.combobox2 = global::Gtk.ComboBox.NewText ();
		this.combobox2.Name = "combobox2";
		this.vbox4.Add (this.combobox2);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.combobox2]));
		w8.Position = 0;
		w8.Expand = false;
		w8.Fill = false;
		// Container child vbox4.Gtk.Box+BoxChild
		this.scrolledwindow2 = new global::Gtk.ScrolledWindow ();
		this.scrolledwindow2.CanFocus = true;
		this.scrolledwindow2.Name = "scrolledwindow2";
		this.scrolledwindow2.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child scrolledwindow2.Gtk.Container+ContainerChild
		this.textview2 = new global::Gtk.TextView ();
		this.textview2.CanFocus = true;
		this.textview2.Name = "textview2";
		this.scrolledwindow2.Add (this.textview2);
		this.vbox4.Add (this.scrolledwindow2);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.scrolledwindow2]));
		w10.Position = 1;
		// Container child vbox4.Gtk.Box+BoxChild
		this.hbuttonbox3 = new global::Gtk.HButtonBox ();
		this.hbuttonbox3.Name = "hbuttonbox3";
		// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
		this.button230 = new global::Gtk.Button ();
		this.button230.CanFocus = true;
		this.button230.Name = "button230";
		this.button230.UseUnderline = true;
		this.button230.Label = global::Mono.Unix.Catalog.GetString ("Adicionar Gramática");
		this.hbuttonbox3.Add (this.button230);
		global::Gtk.ButtonBox.ButtonBoxChild w11 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.button230]));
		w11.Expand = false;
		w11.Fill = false;
		this.vbox4.Add (this.hbuttonbox3);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbuttonbox3]));
		w12.Position = 2;
		w12.Expand = false;
		w12.Fill = false;
		this.notebook1.Add (this.vbox4);
		global::Gtk.Notebook.NotebookChild w13 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.vbox4]));
		w13.Position = 1;
		// Notebook tab
		this.label4 = new global::Gtk.Label ();
		this.label4.Name = "label4";
		this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Gramática Regular");
		this.notebook1.SetTabLabel (this.vbox4, this.label4);
		this.label4.ShowAll ();
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.vbox5 = new global::Gtk.VBox ();
		this.vbox5.Name = "vbox5";
		this.vbox5.Spacing = 6;
		// Container child vbox5.Gtk.Box+BoxChild
		this.combobox3 = global::Gtk.ComboBox.NewText ();
		this.combobox3.Name = "combobox3";
		this.vbox5.Add (this.combobox3);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.combobox3]));
		w14.Position = 0;
		w14.Expand = false;
		w14.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.textview3 = new global::Gtk.TextView ();
		this.textview3.CanFocus = true;
		this.textview3.Name = "textview3";
		this.GtkScrolledWindow.Add (this.textview3);
		this.vbox5.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.GtkScrolledWindow]));
		w16.Position = 1;
		// Container child vbox5.Gtk.Box+BoxChild
		this.hbuttonbox4 = new global::Gtk.HButtonBox ();
		this.hbuttonbox4.Name = "hbuttonbox4";
		// Container child hbuttonbox4.Gtk.ButtonBox+ButtonBoxChild
		this.button1952 = new global::Gtk.Button ();
		this.button1952.CanFocus = true;
		this.button1952.Name = "button1952";
		this.button1952.UseUnderline = true;
		this.button1952.Label = global::Mono.Unix.Catalog.GetString ("Adicionar Expressão");
		this.hbuttonbox4.Add (this.button1952);
		global::Gtk.ButtonBox.ButtonBoxChild w17 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox4 [this.button1952]));
		w17.Expand = false;
		w17.Fill = false;
		this.vbox5.Add (this.hbuttonbox4);
		global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbuttonbox4]));
		w18.Position = 2;
		w18.Expand = false;
		w18.Fill = false;
		this.notebook1.Add (this.vbox5);
		global::Gtk.Notebook.NotebookChild w19 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.vbox5]));
		w19.Position = 2;
		// Notebook tab
		this.label5 = new global::Gtk.Label ();
		this.label5.Name = "label5";
		this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Expressão Regular");
		this.notebook1.SetTabLabel (this.vbox5, this.label5);
		this.label5.ShowAll ();
		this.vbox2.Add (this.notebook1);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.notebook1]));
		w20.Position = 1;
		this.Add (this.vbox2);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 547;
		this.DefaultHeight = 306;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.AutmatoAction.Activated += new global::System.EventHandler (this.inserirAutomato);
		this.AutomatoAction.Activated += new global::System.EventHandler (this.OnAutomatoActionActivated);
		this.AutomatoAction1.Activated += new global::System.EventHandler (this.OnAutomatoAction1Activated);
		this.DeterminizarAutmatoAction.Activated += new global::System.EventHandler (this.OnDeterminizarAutmatoActionActivated);
		this.GramticaAction.Activated += new global::System.EventHandler (this.OnGramticaActionActivated);
		this.GramaticaAction.Activated += new global::System.EventHandler (this.OnGramaticaActionActivated);
		this.UnirAutmatosAction.Activated += new global::System.EventHandler (this.OnUnirAutmatosActionActivated);
		this.InterseccionarAutmatosAction.Activated += new global::System.EventHandler (this.OnInterseccionarAutmatosActionActivated);
		this.MinimizarAutmatoAction.Activated += new global::System.EventHandler (this.OnMinimizarAutmatoActionActivated);
		this.ConverterEREmAFDAction.Activated += new global::System.EventHandler (this.OnConverterEREmAFDActionActivated);
		this.ExpressoAction.Activated += new global::System.EventHandler (this.OnExpressoActionActivated);
		this.ExpressoAction1.Activated += new global::System.EventHandler (this.OnExpressoAction1Activated);
		this.ConverterGramticaParaAFNDAction.Activated += new global::System.EventHandler (this.OnConverterGramticaParaAFNDActionActivated);
		this.ConverterAFDEmGramticaAction.Activated += new global::System.EventHandler (this.OnConverterAFDEmGramticaActionActivated);
		this.combobox1.Changed += new global::System.EventHandler (this.OnCombobox1Changed);
		this.button6.Clicked += new global::System.EventHandler (this.OnButton6Clicked);
		this.combobox2.Changed += new global::System.EventHandler (this.OnCombobox2Changed);
		this.button230.Clicked += new global::System.EventHandler (this.OnButton230Clicked);
		this.combobox3.Changed += new global::System.EventHandler (this.OnCombobox3Changed);
		this.button1952.Clicked += new global::System.EventHandler (this.OnButton1952Clicked);
	}
}
