// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Abbreviation.Screens.iPhone.Search {
	
	
	// Base type probably should be MonoTouch.UIKit.UIViewController or subclass
	[MonoTouch.Foundation.Register("SearchScreen")]
	public partial class SearchScreen {
		
		private MonoTouch.UIKit.UIView __mt_view;
		
		private MonoTouch.UIKit.UISearchBar __mt_srchMain;
		
		private MonoTouch.UIKit.UITableView __mt_tblMain;
		
		#pragma warning disable 0169
		[MonoTouch.Foundation.Connect("view")]
		private MonoTouch.UIKit.UIView view {
			get {
				this.__mt_view = ((MonoTouch.UIKit.UIView)(this.GetNativeField("view")));
				return this.__mt_view;
			}
			set {
				this.__mt_view = value;
				this.SetNativeField("view", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("srchMain")]
		private MonoTouch.UIKit.UISearchBar srchMain {
			get {
				this.__mt_srchMain = ((MonoTouch.UIKit.UISearchBar)(this.GetNativeField("srchMain")));
				return this.__mt_srchMain;
			}
			set {
				this.__mt_srchMain = value;
				this.SetNativeField("srchMain", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("tblMain")]
		private MonoTouch.UIKit.UITableView tblMain {
			get {
				this.__mt_tblMain = ((MonoTouch.UIKit.UITableView)(this.GetNativeField("tblMain")));
				return this.__mt_tblMain;
			}
			set {
				this.__mt_tblMain = value;
				this.SetNativeField("tblMain", value);
			}
		}
	}
}