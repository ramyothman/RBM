<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.Content.EmailTemplates.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
     <div class="col-md-4">
        <h1>
            <asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, ManageEmailTemplates %>"></asp:Literal>
        </h1>

    </div>
    <div class="col-md-7 control-box">
    <ul>
            <li>
                <dx:ASPxButton ID="btnAddNew" runat="server" Text="<%$Resources:ContentManagement, NewEmailTemplate %>"
                    OnClick="btnAddNew_Click">
                    <Image Url="~/images/icons/plus_32.png" Height="24px" Width="24px">
                    </Image>
                </dx:ASPxButton>
            </li>
        </ul>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="gvEmailTemplates" runat="server" 
                        AutoGenerateColumns="False" DataSourceID="dsEmailTemplates" 
                        KeyFieldName="EmailTemplateID" Width="100%">
                        <Columns>
                         <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px" Caption=" ">
                        <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
                    
                        <ClearFilterButton Visible="True">
                        </ClearFilterButton>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption=" " VisibleIndex="1">
                        <DataItemTemplate>
                            <a href='<%#"Save.aspx?ID="+Eval("EmailTemplateID").ToString()%>'>
                                <asp:Image runat="server" ID="img" ImageUrl="~/images/editgrid.png" />
                                </a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="EmailTemplateID" ReadOnly="True" 
                                Visible="False" VisibleIndex="0">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                              <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="SystemEmailTypeID" Caption="Template Type" VisibleIndex="1">
                            <PropertiesComboBox DataSourceID="dsTemplateType" TextField="Name" ValueField="SystemEmailTypeID"></PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="ConferenceID" Caption="conference Name" VisibleIndex="2">
                            <PropertiesComboBox DataSourceID="dsconference" TextField="ConferenceName" ValueField="ConferenceId"></PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="LanguageID" Caption="Language" VisibleIndex="3">
                            <PropertiesComboBox DataSourceID="dsLang" TextField="Name" ValueField="LanguageId"></PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                          
                            <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="5" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="EmailContent" Visible="False" 
                                VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataCheckColumn FieldName="NewRecord" Visible="False" 
                                VisibleIndex="7">
                            </dx:GridViewDataCheckColumn>
                        </Columns>
                         
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
               
                    </dx:ASPxGridView>

                    <asp:ObjectDataSource ID="dsTemplateType" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.Conference.SystemEmailTypeLogic">
                    </asp:ObjectDataSource>

                    <asp:ObjectDataSource ID="dsEmailTemplates" runat="server" 
                        DeleteMethod="Delete" InsertMethod="Insert" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.Conference.EmailTemplateLogic" 
                        UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_EmailTemplateID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="SystemEmailTypeID" Type="Int32" />
                            <asp:Parameter Name="ConferenceID" Type="Int32" />
                            <asp:Parameter Name="LanguageID" Type="Int32" />
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="EmailContent" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="SystemEmailTypeID" Type="Int32" />
                            <asp:Parameter Name="ConferenceID" Type="Int32" />
                            <asp:Parameter Name="LanguageID" Type="Int32" />
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="EmailContent" Type="String" />
                            <asp:Parameter Name="Original_EmailTemplateID" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="dsconference" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.Conference.ConferencesLogic">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="dsLang" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic">
                    </asp:ObjectDataSource>
</asp:Content>
