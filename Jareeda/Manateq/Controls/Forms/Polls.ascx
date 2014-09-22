<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Polls.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Forms.Polls" %>
<div class="aside-block mrg-top">
					<div class="aside-block-head">
						<h1 runat="server" id="ModuleTitleText"></h1>
					</div>
					<div class="aside-block-content" id="Questions" runat="server">
						<div runat="server" id="PollQuestionContainer"  class="vote">	
							
						</div>
                        <div class="vote-btn-container">
                            <a href="javascript:void(0)" onclick="vote()" class="vote_btn">شارك</a>
                        <asp:LinkButton Visible="false" runat="server" ID="VoteBtn" CssClass="vote_btn" Text="صوت" OnClick="VoteBtn_Click" ></asp:LinkButton>
							<asp:LinkButton runat="server" ID="ResultBtn" Visible="false" CssClass="result_btn" Text="النتيجة" OnClick="ResultBtn_Click"></asp:LinkButton>
</div>
					</div>
    <div class="aside-block-content" id="Answers" runat="server">
        <div id="AnswerResultsPoll"></div>
        </div>
				</div>


<script type="text/javascript" language="javascript">
    function vote() {
        var pollDetailsID = $("#<%= Questions.ClientID %>").find("input:checked[type='radio']").val();
        if (pollDetailsID) {
            var manager = new serviceManager();
            manager.serviceUrl = '<%= ResolveUrl("~/Services/PollService.asmx/Vote") %>';
            var str = new String(pollDetailsID + "");
            str = str.replace('ChoiceAnswer','');
            manager.data = '{FormFieldValueId:' + str + ',FormFieldId:' + <%= DataSource.FormFieldId %> + '}';
            //alert(manager.data);
            manager.run(null, function () {
                result(true);
                $("#<%= Questions.ClientID %>").remove();
            });
        }
        else
            alert("لم تقم بتسجيل أي اختيار");
    }

    function result(voted) {
        //alert(voted);
        $("#<%= Questions.ClientID %>").hide();
        var manager = new serviceManager();
        manager.serviceUrl = '<%= ResolveUrl("~/Services/PollService.asmx/GetPollResult") %>';
        manager.data = '{FormFieldId:' + JSON.stringify('<%= DataSource.FormFieldId %>') + '}';
        manager.run("<%= Answers.ClientID %>", function () {
            $("#<%= Answers.ClientID %>").show("slow");
        });
    }

    function back() {
        $("#<%= Answers.ClientID %>").hide();
        $("#<%= Answers.ClientID %>").html("");
        $("#<%= Questions.ClientID %>").show("slow");
    }
</script>