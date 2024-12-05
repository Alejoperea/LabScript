
using Microsoft.JSInterop;

namespace LabScript
{
	public class AlertService : IAsyncDisposable
	{
		readonly Lazy<Task<IJSObjectReference>> jSObjectReference;

		public AlertService (IJSRuntime ijsRuntime)
		{
			this.jSObjectReference = new Lazy<Task<IJSObjectReference>>(()=>
			ijsRuntime.InvokeAsync<IJSObjectReference>("import","./content/LabScript/Pages/Home.razor.js").AsTask());
		}
		public ValueTask DisposeAsync()
		{
			throw new NotImplementedException();
		}
	}
}
