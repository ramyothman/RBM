<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainAdvertisement.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Ads.MainAdvertisement" %>
<div class="ads1">
            <asp:Repeater runat="server" DataSourceID="ObjectDataSourceMainImages">
                <ItemTemplate>
                    <a target="_blank" href='Eval("PhotoLink")'><img width="728" height="90" src='<%#  GetImagePath(Convert.ToString(Eval("PhotoPath"))) %>' alt="" /></a>
                </ItemTemplate>
            </asp:Repeater>
			
		    <asp:ObjectDataSource ID="ObjectDataSourceMainImages" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByConferenceIdandLanguageId" TypeName="BusinessLogicLayer.Components.Conference.ConferenceMainImagesLogic">
                <SelectParameters>
                    <asp:Parameter DefaultValue="2" Name="ConferenceId" Type="Int32" />
                    <asp:Parameter DefaultValue="2" Name="LanguageId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
			
		</div>