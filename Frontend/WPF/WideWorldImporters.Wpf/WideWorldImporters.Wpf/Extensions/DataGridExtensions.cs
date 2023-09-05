// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using System.Reflection;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace WideWorldImporters.Wpf.Extensions
{
    /// <summary>
    /// The DataGrid doesn't remove the Validation Error notification, because of a Binding problem. This 
    /// Bugfix has been shared at: https://stackoverflow.com/a/61613772/513875
    /// </summary>
    public static class DataGridExtensions
    {
        /// <summary>
        /// Identifies the FixBindingGroupValidationErrorsFor attached property. 
        /// </summary>
        public static readonly DependencyProperty FixBindingGroupValidationErrorsForProperty =
            DependencyProperty.RegisterAttached("FixBindingGroupValidationErrorsFor", typeof(DependencyObject), typeof(DataGridExtensions),
                new PropertyMetadata(null, new PropertyChangedCallback(OnFixBindingGroupValidationErrorsForChanged)));

        /// <summary>
        /// Gets the value of the FixBindingGroupValidationErrorsFor property
        /// </summary>
        public static DependencyObject GetFixBindingGroupValidationErrorsFor(DependencyObject obj)
        {
            return (DependencyObject)obj.GetValue(FixBindingGroupValidationErrorsForProperty);
        }

        /// <summary>
        /// Sets the value of the FixBindingGroupValidationErrorsFor property
        /// </summary>
        public static void SetFixBindingGroupValidationErrorsFor(DependencyObject obj, DependencyObject value)
        {
            obj.SetValue(FixBindingGroupValidationErrorsForProperty, value);
        }

        /// <summary>
        /// Handles property changed event for the FixBindingGroupValidationErrorsFor property.
        /// </summary>
        private static void OnFixBindingGroupValidationErrorsForChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DependencyObject oldobj = (DependencyObject)e.OldValue;
            if (oldobj != null)
            {
                BindingGroup group = FindBindingGroup(d); //if d!=DataGridCell, use (DependencyObject)e.NewValue
                var leftOverErrors = group.ValidationErrors != null ?
                    Validation.GetErrors(group.Owner).Except(group.ValidationErrors).ToArray() : Validation.GetErrors(group.Owner).ToArray();
                foreach (var error in leftOverErrors)
                {
                    //HINT: BindingExpressionBase.Detach() removes the reference to BindingGroup, before ValidationErrors are removed.
                    if (error.BindingInError is BindingExpressionBase binding && (binding.Target == null ||
                        TreeHelper.IsDescendantOf(binding.Target, oldobj)) && binding.BindingGroup == null &&
                        (binding.ValidationErrors == null || binding.ValidationErrors.Count == 0 || !binding.ValidationErrors.Contains(error)))
                    {
                        typeof(Validation).GetMethod("RemoveValidationError", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, new object[] { error, group.Owner, group.NotifyOnValidationError });
                    }
                }
            }
        }

        private static BindingGroup FindBindingGroup(DependencyObject obj)
        {
            do
            {
                if (obj is FrameworkElement fe)
                {
                    return fe.BindingGroup;
                }
                if (obj is FrameworkContentElement fce)
                {
                    return fce.BindingGroup;
                }
                obj = LogicalTreeHelper.GetParent(obj);
            } while (obj != null);
            return null;
        }

        private static class TreeHelper
        {
            private static DependencyObject GetParent(DependencyObject element, bool recurseIntoPopup)
            {
                if (recurseIntoPopup)
                {
                    // Case 126732 : To correctly detect parent of a popup we must do that exception case
                    Popup popup = element as Popup;

                    if ((popup != null) && (popup.PlacementTarget != null))
                        return popup.PlacementTarget;
                }

                Visual visual = element as Visual;
                DependencyObject parent = (visual == null) ? null : VisualTreeHelper.GetParent(visual);

                if (parent == null)
                {
                    // No Visual parent. Check in the logical tree.
                    parent = LogicalTreeHelper.GetParent(element);

                    if (parent == null)
                    {
                        FrameworkElement fe = element as FrameworkElement;

                        if (fe != null)
                        {
                            parent = fe.TemplatedParent;
                        }
                        else
                        {
                            FrameworkContentElement fce = element as FrameworkContentElement;

                            if (fce != null)
                            {
                                parent = fce.TemplatedParent;
                            }
                        }
                    }
                }

                return parent;
            }

            public static bool IsDescendantOf(DependencyObject element, DependencyObject parent)
            {
                return TreeHelper.IsDescendantOf(element, parent, true);
            }

            public static bool IsDescendantOf(DependencyObject element, DependencyObject parent, bool recurseIntoPopup)
            {
                while (element != null)
                {
                    if (element == parent)
                        return true;

                    element = TreeHelper.GetParent(element, recurseIntoPopup);
                }

                return false;
            }
        }
    }
}
