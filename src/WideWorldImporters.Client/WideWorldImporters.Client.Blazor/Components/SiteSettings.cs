using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace WideWorldImporters.Client.Blazor.Components
{
    public partial class SiteSettings
    {
        private IDialogReference? _dialog;

        [Inject]
        private GlobalState GlobalState { get; set; } = default!;

        private async Task OpenSiteSettingsAsync()
        {
            _dialog = await DialogService.ShowPanelAsync<SiteSettingsPanel>(GlobalState, new DialogParameters<GlobalState>()
            {
                ShowTitle = true,
                Title = "Site settings",
                Content = GlobalState,
                Alignment = HorizontalAlignment.Right,
                PrimaryAction = "OK",
                SecondaryAction = null,
                ShowDismiss = true
            });

            DialogResult result = await _dialog.Result;
            HandlePanel(result);
        }

        private void HandlePanel(DialogResult result)
        {
            if (result.Cancelled)
            {
                return;
            }

            if (result.Data is not null)
            {
                GlobalState? state = result.Data as GlobalState;

                GlobalState.SetDirection(state!.Dir);
                GlobalState.SetLuminance(state.Luminance);
                GlobalState.SetColor(state!.Color);

                return;
            }
        }
    }
}
