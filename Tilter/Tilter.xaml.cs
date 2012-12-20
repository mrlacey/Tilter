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

        /// <summary>
        /// Initializes a new instance of the <see cref="Tilter"/> class.
        /// </summary>
        public Tilter()
        {
            InitializeComponent();
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
                return (ICommand)GetValue(CommandProperty);
            }

            set
            {
                SetValue(CommandProperty, value);
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
                return GetValue(CommandParameterProperty);
            }

            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the content that is contained within a user control.
        /// </summary>
        /// <returns>The content of the user control.</returns>
        public new FrameworkElement Content
        {
            get
            {
                return (FrameworkElement)GetValue(ContentProperty);
            }

            set
            {
                SetValue(ContentProperty, value);
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
