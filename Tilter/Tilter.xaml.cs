//-----------------------------------------------------------------------
// <copyright file="Tilter.xaml.cs" company="Matt lacey Limited">
//     Copyright © 2012 Matt Lacey
// </copyright>
//-----------------------------------------------------------------------
namespace Mrlacey
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Enable encapsulation of Toolkit.TiltEffect functionality around
    /// arbitrary controls
    /// </summary>
    public partial class Tilter : UserControl
    {
        /// <summary>
        /// Backing property for the Command Property
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(Tilter),
                new PropertyMetadata(null, OnCommandChanged));

        /// <summary>
        /// Backing property for the Command Parameter
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                "CommandParameter",
                typeof(object),
                typeof(Tilter),
                new PropertyMetadata(null, OnCommandParameterChanged));

        /// <summary>
        /// Backing property for the content
        /// </summary>
        public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(
                "Content",
                typeof(FrameworkElement),
                typeof(Tilter),
                new PropertyMetadata(null, OnContentChanged));

        public readonly DependencyProperty TapCommandProperty =
    DependencyProperty.Register(
        "TapCommand",
        typeof(ICommand),
        typeof(Tilter),
        new PropertyMetadata(null));

        public readonly DependencyProperty TapCommandParameterProperty =
            DependencyProperty.Register(
                "TapCommandParameter",
                typeof(object),
                typeof(Tilter),
                new PropertyMetadata(null));

        /// <summary>
        /// Initializes a new instance of the <see cref="Tilter"/> class.
        /// </summary>
        public Tilter()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public ICommand Command
        {
            get
            {
                return (ICommand)this.GetValue(CommandProperty);
            }

            set
            {
                this.SetValue(CommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the command parameter.
        /// </summary>
        /// <value>
        /// The command parameter.
        /// </value>
        public object CommandParameter
        {
            get
            {
                return this.GetValue(CommandParameterProperty);
            }

            set
            {
                this.SetValue(CommandParameterProperty, value);
            }
        }

        public ICommand TapCommand
        {
            get { return (ICommand)GetValue(this.TapCommandProperty); }
            set { this.SetValue(this.TapCommandProperty, value); }
        }

        public object TapCommandParameter
        {
            get { return this.GetValue(this.TapCommandParameterProperty); }
            set { this.SetValue(this.TapCommandParameterProperty, value); }
        }

        /// <summary>
        /// Gets or sets the content that is contained within a user control.
        /// </summary>
        /// <returns>The content of the user control.</returns>
        public new FrameworkElement Content
        {
            get
            {
                return (FrameworkElement)this.GetValue(ContentProperty);
            }

            set
            {
                this.SetValue(ContentProperty, value);
            }
        }

        public void ControlTapped(object sender, GestureEventArgs e)
        {
            if (this.TapCommand != null)
            {
                this.TapCommand.Execute(this.TapCommandParameter);
            }
        }

        /// <summary>
        /// Raises the ContentChanged event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnContentChanged(DependencyPropertyChangedEventArgs e)
        {
            if (this.Content != null)
            {
                this.TheContent.Content = this.Content;
            }
        }

        /// <summary>
        /// Called when [command changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = (Tilter)d;
            t.InternalButton.Command = (ICommand)e.NewValue;
        }

        /// <summary>
        /// Called when the command parameter is changed.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = (Tilter)d;
            t.InternalButton.CommandParameter = e.NewValue;
        }

        /// <summary>
        /// Called when the content is changed.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Tilter)d).OnContentChanged(e);
        }
    }
}
