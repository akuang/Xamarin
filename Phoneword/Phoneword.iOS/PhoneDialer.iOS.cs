using System.Threading.Tasks;
using Foundation;
using UIKit;
using Xamarin.Forms;

// This same attribute definition needs to go in each platform-specific file
[assembly: Dependency(typeof(Phoneword.iOS.PhoneDialer))]

namespace Phoneword.iOS
{
	public class PhoneDialer : IDialer
	{
		public Task<bool> DialAsync(string number)
		{
			return Task.FromResult(
				UIApplication.SharedApplication.OpenUrl(
				new NSUrl("tel:" + number))
			);
		}
	}
}
