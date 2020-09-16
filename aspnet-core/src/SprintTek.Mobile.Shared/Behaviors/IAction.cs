using Xamarin.Forms.Internals;

namespace SprintTek.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}