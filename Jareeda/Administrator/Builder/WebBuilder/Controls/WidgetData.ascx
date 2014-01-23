<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetData.ascx.cs" Inherits="Administrator.Builder.WebBuilder.Controls.WidgetData" %>

<dx:aspxcallbackpanel runat="server" width="100%" id="callBackPanel" ClientInstanceName="modCallbackPanel">
    <PanelCollection>
<dx:PanelContent runat="server" SupportsDisabledAttribute="True">
    <table>
    <tr>
        <td>
            Items Number
        </td>
        <td>
            <dx:aspxspinedit runat="server" id="modItemsNumber" ClientInstanceName="modItemsNumber" height="21px" number="0">
</dx:aspxspinedit>
        </td>
    </tr>
    <tr>
        <td>
            Items Per Page
        </td>
        <td>
            <dx:aspxspinedit runat="server" id="modItemsPerPage" ClientInstanceName="modItemsPerPage" height="21px" number="0">
</dx:aspxspinedit>
        </td>
    </tr>
    <tr>
        <td>
            Is Active
        </td>
        <td>
            <dx:aspxcheckbox id="modIsActive" ClientInstanceName="modIsActive"  runat="server"></dx:aspxcheckbox>
        </td>
    </tr>
</table>
</dx:PanelContent>
</PanelCollection>
</dx:aspxcallbackpanel>
