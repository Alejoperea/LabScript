
using Microsoft.JSInterop;

namespace LabScript
{
	public class AlertService : IAsyncDisposable, IAlertService
	{
		readonly Lazy<Task<IJSObjectReference>> jSObjectReference;

		public AlertService(IJSRuntime ijsRuntime)
		{
			this.jSObjectReference = new Lazy<Task<IJSObjectReference>>(() =>
			ijsRuntime.InvokeAsync<IJSObjectReference>("import", "./Home.js").AsTask());
		}
		public async ValueTask DisposeAsync()
		{
			if (jSObjectReference.IsValueCreated)
			{
				IJSObjectReference moduleJs = await jSObjectReference.Value;
				await moduleJs.DisposeAsync();
			}
		}

		public async Task CallsAlertFunction()
		{
			var jsModule = await jSObjectReference.Value;

			await jsModule.InvokeVoidAsync("jsFuncion");
		}
	}
}
