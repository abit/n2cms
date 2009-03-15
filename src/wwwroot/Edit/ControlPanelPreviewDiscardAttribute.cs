using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using N2.Web.UI.WebControls;
using N2.Web;

namespace N2.Edit
{
	/// <summary>
	/// Used internally to add the dicard preview button.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class ControlPanelPreviewDiscardAttribute : ControlPanelLinkAttribute
	{
		public ControlPanelPreviewDiscardAttribute(string toolTip, int sortOrder)
			: base("cpPreviewDiscard", "~/edit/img/ico/cancel.gif", null, toolTip, sortOrder, ControlPanelState.Previewing)
		{
		}

		public override Control AddTo(Control container, PluginContext context)
		{
			if(!ActiveFor(container, context.State)) return null;
			if (context.Selected.VersionOf == null) return null;

			HyperLink hl = new HyperLink();
			hl.Text = GetInnerHtml(IconUrl, ToolTip, Title);
			hl.NavigateUrl = Url.Parse("~/Edit/DiscardPreview.aspx").AppendQuery("selectedUrl", context.Selected.Url);
			hl.CssClass = "cancel";
			hl.Attributes["onclick"] = "return confirm('Are you certain?');";
			container.Controls.Add(hl);

			return hl;
		}

		protected void RedirectTo(Page page, ContentItem item)
		{
			string url = page.Request["returnUrl"];
			if (string.IsNullOrEmpty(url))
				url = Context.Current.EditManager.GetPreviewUrl(item);

			page.Response.Redirect(url);
		}
	}
}