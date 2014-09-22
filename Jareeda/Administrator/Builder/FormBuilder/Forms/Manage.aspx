<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.Builder.FormBuilder.Forms.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
   <div class="col-md-4">
        <h1>
            <asp:Literal ID="AFTitle" runat="server" Text="Manage Forms"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
     

    </div>
   


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
       <dx:ASPxGridView ID="gridForms" runat="server" AutoGenerateColumns="False" 
        DataSourceID="FormsObjectDS" KeyFieldName="FormDocumentID">
        <Columns>
             <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px" Caption=" ">
                        <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
                        <EditButton Visible="True">
                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                            </Image>
                        </EditButton>
                        <NewButton Visible="True">
                            <Image Height="16px" Url="~/images/newgrid.png" Width="16px">
                            </Image>
                        </NewButton>
                        <CancelButton>
                            <Image Height="32px" Url="~/images/cancelsave32.png" Width="32px">
                            </Image>
                        </CancelButton>
                        <UpdateButton>
                            <Image Height="32px" Url="~/images/filesave32.png" Width="32px">
                            </Image>
                        </UpdateButton>
                        <ClearFilterButton Visible="True">
                        </ClearFilterButton>
                    </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="Id" FieldName="FormDocumentID" 
                ReadOnly="True" VisibleIndex="1" Width="50px">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="View" FieldName="FormDocumentID" 
                ReadOnly="True" VisibleIndex="2" Width="50px">
                <EditFormSettings Visible="False" />
                <DataItemTemplate>
                    <a id="A1" target="_blank" runat="server" href='<%# "../View.aspx?code=" + Eval("FormDocumentID") %>'><img id="Img1" src="~/Builder/FormBuilder/images/download.png" alt="Download Excel" runat="server" /> </a>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Status" 
                FieldName="FormDocumentStatusID" VisibleIndex="2" Width="50px">
                <PropertiesComboBox DataSourceID="StatusObjectDS" TextField="StatusName" 
                    ValueField="FormDocumentStatusID" ValueType="System.Int32">
                </PropertiesComboBox>
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="3" Width="200px">
                <EditFormSettings ColumnSpan="2" />
                <DataItemTemplate>
                    <a href='../Builder.aspx?code=<%# Eval("FormDocumentID") %>'><%# Eval("Title") %></a>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Description" Visible="False" 
                VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="StartDate" VisibleIndex="5">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="EndDate" VisibleIndex="6">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="ConfirmationText" Visible="False" 
                VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CreatorID" VisibleIndex="8" 
                Visible="False">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="CreationDate" VisibleIndex="9" 
                Visible="False">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataCheckColumn FieldName="SendEmail" Visible="False" 
                VisibleIndex="10">
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="SendSMS" Visible="False" 
                VisibleIndex="11">
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="AllowModify" VisibleIndex="12" 
                Visible="False">
            </dx:GridViewDataCheckColumn>
        </Columns>
                    <SettingsBehavior ConfirmDelete="True" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="600px" />
        <Settings ShowFilterRow="True" />
      
        
                    <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
      
        
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="FormsObjectDS" runat="server" DeleteMethod="Delete" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetAll" 
        TypeName="BusinessLogicLayer.Components.FormBuilder.FormDocumentLogic" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_FormDocumentID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="FormDocumentStatusID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="StartDate" Type="DateTime" />
            <asp:Parameter Name="EndDate" Type="DateTime" />
            <asp:Parameter Name="ConfirmationText" Type="String" />
            <asp:SessionParameter Name="CreatorID" SessionField="MFCreatorID" 
                Type="Int32" />
            <asp:SessionParameter Name="CreationDate" SessionField="MFCreationDate" 
                Type="DateTime" />
            <asp:Parameter Name="SendEmail" Type="Boolean" />
            <asp:Parameter Name="SendSMS" Type="Boolean" />
            <asp:Parameter Name="AllowModify" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FormDocumentStatusID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="StartDate" Type="DateTime" />
            <asp:Parameter Name="EndDate" Type="DateTime" />
            <asp:Parameter Name="ConfirmationText" Type="String" />
            <asp:Parameter Name="CreatorID" Type="Int32" />
            <asp:Parameter Name="CreationDate" Type="DateTime" />
            <asp:Parameter Name="SendEmail" Type="Boolean" />
            <asp:Parameter Name="SendSMS" Type="Boolean" />
            <asp:Parameter Name="AllowModify" Type="Boolean" />
            <asp:Parameter Name="Original_FormDocumentID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="StatusObjectDS" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
        TypeName="BusinessLogicLayer.Components.FormBuilder.FormDocumentStatusLogic">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="QualityGroupObjectDS" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="ViewQualityGroup" 
        TypeName="BusinessLogicLayer.Components.QualityGroupLogic">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="FormGroupsObjectDS" runat="server" 
        DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetAllByFormDocumentId" 
        TypeName="BusinessLogicLayer.Components.FormQualityGroupLogic" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_FormQualityGroupId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter DefaultValue="0" Name="FormDocumentId" 
                SessionField="FormBuilderDocumentId" Type="Int32" />
            <asp:Parameter Name="QualityGroupId" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="FormDocumentId" 
                SessionField="FormBuilderDocumentId" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter DefaultValue="0" Name="FormDocumentId" 
                SessionField="FormBuilderDocumentId" Type="Int32" />
            <asp:Parameter Name="QualityGroupId" Type="Int32" />
            <asp:Parameter Name="Original_FormQualityGroupId" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
           
</asp:Content>
