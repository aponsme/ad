
// This file has been generated by the GUI designer. Do not modify.
namespace Serpis.Ad
{
	public partial class WindowRemove
	{
		private global::Gtk.VBox vbox4;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Label label2;
		private global::Gtk.Entry entry;
		private global::Gtk.HBox hbox4;
		private global::Gtk.Button button;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Serpis.Ad.WindowRemove
			this.Name = "Serpis.Ad.WindowRemove";
			this.Title = global::Mono.Unix.Catalog.GetString ("WindowRemove");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Serpis.Ad.WindowRemove.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Introduce el id del elemento que quieras borrar:");
			this.hbox3.Add (this.label2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label2]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.entry = new global::Gtk.Entry ();
			this.entry.CanFocus = true;
			this.entry.Name = "entry";
			this.entry.IsEditable = true;
			this.entry.InvisibleChar = '•';
			this.hbox3.Add (this.entry);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.entry]));
			w2.Position = 1;
			this.vbox4.Add (this.hbox3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbox3]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.button = new global::Gtk.Button ();
			this.button.CanFocus = true;
			this.button.Name = "button";
			this.button.UseUnderline = true;
			this.button.Label = global::Mono.Unix.Catalog.GetString ("Borrar");
			this.hbox4.Add (this.button);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.button]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox4.Add (this.hbox4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbox4]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.Add (this.vbox4);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 487;
			this.DefaultHeight = 300;
			this.Show ();
		}
	}
}