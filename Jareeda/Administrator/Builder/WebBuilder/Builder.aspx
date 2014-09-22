<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminLight.master" AutoEventWireup="true" CodeBehind="Builder.aspx.cs" Inherits="Administrator.Builder.WebBuilder.Builder" %>
<%@ Register Src="~/Builder/WebBuilder/Controls/WidgetData.ascx" TagName="WidgetMainData" TagPrefix="natiq" %>
<%@ Register Src="~/Builder/WebBuilder/Controls/NewsData.ascx" TagName="WidgetNewsData" TagPrefix="natiq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <%--<script src="js/jquery.js"></script>
    <script src="js/jquery.ui.js"></script>--%>
    <link rel='stylesheet' href='css/iframe.css' type='text/css' media='all' />
    
    <link runat="server" id="JareedaStyleReference" href="<%$Resources:ContentManagement, JareedaStyleAdmin %>" rel="stylesheet" />
    <script src="js/mouseover_popup.js"></script>
    <script src="js/jquery.animate-shadow.js"></script>
    <script src="js/jquery.hoverIntent.js"></script>
    <script src="js/jquery.iframe.js"></script>
    <script src="js/jquery.scrollto.js"></script>
    
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="Scripts/JQuery/JSON.js" type="text/javascript"></script>
    <script src="Scripts/Tools.js"></script>
    <script src="Scripts/jquery.simulate.js"></script>
    <script src="Scripts/BlockBuilder.js"></script>
    <script src="Scripts/LayoutBuilder.js"></script>
    <script type="text/javascript">
        $(function () {
            var $iframe = $("#contentIFrame").contents();
            var blockContainerContent = $('#blockContentTest', $iframe);
            $(".module-s-box").draggable({
                
                scroll: "false",
                appendTo: "body",
                helper: function () { return $(this).clone(); },
                iframeFix: true,
                revert: 'invalid',
                cursor: "move"
            });

           
            
        });

        function AddItem(container) {
            AddNewItem(container);
        }
        $(function () {
            $("#grid-container").sortable({
                placeholder: "ui-state-highlight",
                handle: '.block-header'
            });

            $("#grid-container").disableSelection();

            $(".block-content").sortable({
                placeholder: "ui-state-highlight",
                handle: '.block-header'

            });
        });
        var currentOpenedWidget = null;
        function OpenWidgetPopup(id, widget) {
            currentOpenedWidget = widget;
            popupSettings.Show();
            modItemsNumber.SetText(widget.itemsNumber);
            modItemsPerPage.SetText(widget.itemsPerPage);
            modIsActive.SetValue(widget.isActive);
            callBackPanelGeneral.PerformCallback(widget.id);
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">

     <div class="col-md-4">
        <h1>
            <asp:Literal runat="server" Text="<%$Resources:ContentManagement, WBTitle %>"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
      <ul>
          <li>
              <dx:ASPxButton ID="btnConfirmationMessage" runat="server" Text="Add Block" Font-Size="8pt" ImagePosition="Top" ImageSpacing="0px" AutoPostBack="false">
                    <Image Url="images/Cloud_Add.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                  <ClientSideEvents Click="function(s,e){ AddElement(cmbPosition); }" />
                </dx:ASPxButton>
          </li>
          
          <li>
              <dx:ASPxButton ID="btnSave" runat="server" Text="<%$Resources:ContentManagement, Save %>" Font-Size="8pt" ImagePosition="Top" ImageSpacing="0px" AutoPostBack="false">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-save.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                  <ClientSideEvents Click="function(s,e){ SaveLayout(); }" />
                </dx:ASPxButton>
          </li>
          <li>
              <%-- <a href="javascript:SaveData();"><img src="images/filesaveas.png" class="ImageLink" alt="Save" /></a><a href="javascript:popupSurveySettings.Show();"><img src="images/page_accept.png" class="ImageLink" alt="Edit Confirmation" /></a>--%>
          </li>
      </ul>

    </div>
     <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel"
        Modal="True" Text="">
         <image url="~/Builder/WebBuilder/images/490.GIF">
         </image>
         <loadingdivstyle backcolor="#4C4C4C">
         </loadingdivstyle>
    </dx:ASPxLoadingPanel>
    <dx:aspxcallback runat="server" id="saveCallBack" ClientInstanceName="saveCallBack"   OnCallback="saveCallBack_Callback">
          <ClientSideEvents CallbackComplete="function(s, e) { LoadingPanel.Hide(); LoadingPanel.Show();
                         loadCallBack.PerformCallback(cmbSection.GetValue() + ',' + cmbPageType.GetValue()); jSuccess('Saved Successfully'); }" />
    </dx:aspxcallback>
    <dx:aspxcallback runat="server" id="loadCallBack" ClientInstanceName="loadCallBack" OnCallback="loadCallBack_Callback"  >
          <ClientSideEvents CallbackComplete="function(s, e) { LoadingPanel.Hide(); 
              
              hiddenJSONLoad.Set('JSONLayout',e.result); 
              LoadLayout(); }" />
    </dx:aspxcallback>
    <dx:aspxhiddenfield id="hiddenJSONLoad" ClientInstanceName="hiddenJSONLoad" runat="server"></dx:aspxhiddenfield>
  <%--  <h1>
        <asp:Literal runat="server" Text="<%$Resources:ContentManagement, WBTitle %>"></asp:Literal>
        </h1>
    
    <div class="toolbar">
       
        <ul>
             <li>
                <a href="javascript:void(0)" onclick="AddElement(cmbPosition)"><img src="images/Cloud_Add.png" /></a>
            </li>
            <li>
                <a href="javascript:void(0)" onclick="SaveLayout()"><img src="images/Save-as.png" /></a>
            </li>
        </ul>
    </div>--%>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row jareeda-container">
        <div class="col-md-3 jareeda-content-left left-builder">
         <ul class="nav nav-tabs jareeda-tabs ">
            <li class="active"><a href="#tabLayout" data-toggle="tab"><asp:Literal runat="server"  Text="<%$Resources:ContentManagement, SBLayout %>" ></asp:Literal></a></li>
            <li><a href="#tabBlocks" data-toggle="tab"><asp:Literal runat="server"  Text="<%$Resources:ContentManagement, SBBlocks %>" ></asp:Literal></a></li>
        </ul>
            <div class="tab-content jareeda-tabs-content">
                <div class="tab-pane fade in active" id="tabLayout">
      <div >
            <section>
        <span class="span"> 
            <asp:Literal runat="server" Text="<%$Resources:ContentManagement, WBSite %>"></asp:Literal>
             </span> <dx:aspxcombobox runat="server" ID="cmbSite" DataSourceID="SiteObjectDS" TextField="Name" ValueField="SiteId" ValueType="System.Int32">
                    <clientsideevents selectedindexchanged="function(s, e) {
	cmbSection.PerformCallback(s.GetValue());
	cmbPosition.PerformCallback(s.GetValue());
}" />
                </dx:aspxcombobox>
                <asp:ObjectDataSource ID="SiteObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic"></asp:ObjectDataSource>
    </section> 
    <section>
         <span class="span"> 
          <asp:Literal runat="server" Text="<%$Resources:ContentManagement, WBSection %>"></asp:Literal>
           </span> <dx:aspxcombobox runat="server" ID="cmbSection" ClientInstanceName="cmbSection" DataSourceID="SectionObjectDS" OnCallback="cmbSection_Callback" TextField="Name" ValueField="SiteSectionId" ValueType="System.Int32">
                     <clientsideevents selectedindexchanged="function(s, e) {
                         //alert('test');
                         LoadingPanel.Show();
                         loadCallBack.PerformCallback(s.GetValue() + ',' + cmbPageType.GetValue());
	
}" />
                                                    <ValidationSettings CausesValidation="True" Display="Dynamic">
                                                        <RequiredField IsRequired="True" />
                     </ValidationSettings>
                                                    </dx:aspxcombobox>
                <asp:ObjectDataSource ID="SectionObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="SiteId" SessionField="HPDSiteId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    </section>
    <section>
         <span class="span"> 
       <asp:Literal runat="server" Text="<%$Resources:ContentManagement, WBPosition %>"></asp:Literal>
        </span><dx:aspxcombobox runat="server" ID="cmbPosition" ClientInstanceName="cmbPosition" DataSourceID="PositionObjectDS" OnCallback="cmbPosition_Callback" TextField="Name" ValueField="SitePageLayoutID" ValueType="System.Int32" TextFormatString="{1}" Width="240px">
                    <Columns>
                        <dx:ListBoxColumn Caption="ID" width="30" FieldName="SitePageLayoutID" />
                        <dx:ListBoxColumn Caption="Name" FieldName="Name" />
                        <dx:ListBoxColumn Caption="Design" Name="DesignCode"  FieldName="DesignCode" />
                        <dx:ListBoxColumn Caption="Class" Name="PreviewClass"  FieldName="PreviewClass" />
                        
                    </Columns>
                  
                </dx:aspxcombobox>
                <asp:ObjectDataSource ID="PositionObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllBySiteId" TypeName="BusinessLogicLayer.Components.ContentManagement.SitePageLayoutLogic">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="SiteID" SessionField="HPDSiteId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    </section>
    <section>
        <span class="span"> 
                            <asp:Literal runat="server" Text="<%$Resources:ContentManagement, WBType %>"></asp:Literal>
                             </span><dx:aspxcombobox runat="server" ID="cmbPageType" ClientInstanceName="cmbPageType"  TextField="Name" ValueField="SitePageTypeID" ValueType="System.Int32" TextFormatString="{1}" Width="240px" DataSourceID="ObjectDataSourcePageType">
                      <clientsideevents selectedindexchanged="function(s, e) {
                         //alert('test');
                         LoadingPanel.Show();
                         loadCallBack.PerformCallback(cmbSection.GetValue() + ',' + cmbPageType.GetValue());
	
}" />
                      <ValidationSettings CausesValidation="True" Display="Dynamic">
                          <RequiredField IsRequired="True" />
                      </ValidationSettings>
                </dx:aspxcombobox>
                <dx:aspxcheckbox runat="server" id="chkIsMain" ClientInstanceName="chkIsMain" text="Is Main Section"></dx:aspxcheckbox>
                <asp:ObjectDataSource ID="ObjectDataSourcePageType" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SitePageTypeLogic"></asp:ObjectDataSource>
    </section>
          </div>
                    </div>
                <div class="tab-pane fade" id="tabBlocks">
                    <div style="clear:both;" >
                        <div id="addWidget" >

        
     <asp:Repeater runat="server" ID="ImportantNewsRepeater" DataSourceID="ObjectDataSourceCMTObjectDS">
                        <ItemTemplate>
                            <div class="module-s-box"  rel='<%# Eval("ContentModuleTypeID") + ";" + Eval("Name") + ";" + GetImagePath(Eval("ImagePreview").ToString()) + ';' + Eval("PositionID") %>'>
                                <a href="javascript:void();">
                                    <center><span><%# Eval("Name") %></span></center>
                                    <img runat="server" width="72" height="80" onmouseover='<%# "showtrail(\""  + GetImagePath(Eval("ImagePreview").ToString()) +"\",\"" + Eval("Name") + "\",310,250)" %>' onmouseout="hidetrail()"  src='<%# GetImagePath(Eval("ImagePreview").ToString()) %>' />
                                    <div class="location"><%# Eval("PositionName") %></div>
                                </a>
                            </div>
                            </ItemTemplate>
         </asp:Repeater>
                            <div style="clear:both;"></div>
     <asp:ObjectDataSource ID="ObjectDataSourceCMTObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllBySiteID" TypeName="BusinessLogicLayer.Components.ContentManagement.ContentModuleTypeLogic">
         <SelectParameters>
             <asp:Parameter DefaultValue="71" Name="SiteID" Type="Int32" />
         </SelectParameters>
     </asp:ObjectDataSource>
        </div>
                    </div>
                    </div>
                </div>
        </div>
        <div class="col-md-9  main-builder">
              <div style="width:100%;"" class="visual-editor-iframe-grid">
          <div id="whitewrap">
	<div id="wrapper-1" class="wrapper grid-active">
		<div id="grid" class="grid-grey">
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
		</div>
		<!-- #grid -->
		<div id="grid-container" class="grid-container">
			
			
		</div>
        <div class="clear" style="clear:both;"></div>
        <br />
		<!-- .grid-container --></div>
	<!-- #wrapper-1 --> 
	
</div>
        <div class="clear" style="clear:both;"></div>
    </div>
 <dx:aspxpopupcontrol  runat="server" ID="popupSettings" AllowResize="True" ClientInstanceName="popupSettings" HeaderText="Settings" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px"><ContentCollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
    <table>
                    <tr>
                        <td>
                            <natiq:WidgetMainData runat="server" ID="widgetMainData" />
                        </td>
                    </tr>
        <tr>
            <td>
                <natiq:WidgetNewsData runat="server" id="widgetNewsData" />
                <dx:ASPxCallbackPanel ID="callbackPanelSettings" runat="server" ClientInstanceName="callbackPanelSettings" Width="100%" OnCallback="callbackPanelSettings_Callback">
        <panelcollection>
            <dx:PanelContent runat="server">
                
                
            </dx:PanelContent>
        </panelcollection>
    </dx:ASPxCallbackPanel>
            </td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td>
                <dx:ASPxButton runat="server" Text="Save" ClientInstanceName="btnSaveOptions" AutoPostBack="False">
                    <clientsideevents Click="function(s, e) {
	
	currentOpenedWidget.itemsNumber = modItemsNumber.GetText();
           currentOpenedWidget.itemsPerPage = modItemsPerPage.GetText();
            currentOpenedWidget.isActive = modIsActive.GetValue();
                        popupSettings.Hide();
}" />
                </dx:ASPxButton>
            </td>
        </tr>
                </table>
    
            </dx:PopupControlContentControl>
</ContentCollection>
        </dx:aspxpopupcontrol>
        </div>
    </div>
  
</asp:Content>
