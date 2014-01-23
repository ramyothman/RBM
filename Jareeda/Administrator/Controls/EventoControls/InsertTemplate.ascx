<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InsertTemplate.ascx.cs" Inherits="Administrator.Controls.EventoControls.InsertTemplate" %>

    <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="loadingPanel">
</dx:ASPxLoadingPanel>
<dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="templateObjectDS"
    AutoGenerateColumns="False" Width="400px" ClientInstanceName="templatesGrid"
    KeyFieldName="EmailTemplateID">
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" 
            Width="20px">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="Name"  VisibleIndex="0">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="EmailContent" VisibleIndex="1" 
            Visible="False">
        </dx:GridViewDataTextColumn>
    </Columns>
    <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" 
        AllowSelectSingleRowOnly="True" />
    <SettingsPager Mode="ShowAllRecords">
    </SettingsPager>
    <Settings ShowColumnHeaders="False" />
    <ClientSideEvents RowDblClick="OnGridRowDblClick" />
</dx:ASPxGridView>
<asp:ObjectDataSource ID="templateObjectDS" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
    TypeName="BusinessLogicLayer.Components.Conference.EmailTemplateLogic">
</asp:ObjectDataSource>
<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/InsertTemplateData.xml"
    TransformFile="~/App_Data/InsertTemplateData.xsl" XPath="//Templates/*"></asp:XmlDataSource>
<div style="margin-top: 10px">
    <dx:ASPxCheckBox ID="OverwriteCheckBox" runat="server" Checked="True" Text="Overwrite content"
        ClientInstanceName="overwriteCheckBox">
    </dx:ASPxCheckBox>
</div>