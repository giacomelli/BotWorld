<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="Pages_Home" %>

<%@ Register assembly="DG.BotWorld.Web" namespace="DG.BotWorld.Web.UI.Controls" tagprefix="bw" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <legend>Environments</legend>
        <bw:BWGridView ID="grvEnvironments" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyNames="Name"
            OnSelectedIndexChanged="grvEnvironments_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectImageUrl="~/Images/SelectBotIcon.png"
                    ButtonType="Image">
                    <ItemStyle Width="32px" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="Environment">
                    <ItemTemplate>
                        <asp:Image ID="imgBot" runat="server" ImageUrl='<%# WebSiteEnvironmentHelper.GetEnvironmentImageUrl(Eval("Name")) %>'
                            Width="128px" />
                        <asp:Label ID="lblEnvironmentName" runat="server" Text='<%# Eval("Name") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Description" HeaderText="Description" ShowHeader="False" />
                <asp:BoundField DataField="MinBotsNumber" HeaderText="Min. bots" ShowHeader="true" />
                <asp:BoundField DataField="MaxBotsNumber" HeaderText="Max. bots" ShowHeader="true" />
            </Columns>
        </bw:BWGridView>
    </fieldset>
    <br />
    <fieldset>
        <legend>Bots ranking</legend>
        <bw:BWGridView ID="grvBotsRanking" runat="server" AutoGenerateColumns="False" 
            CssClass="Grid">
            <Columns>
                <asp:TemplateField HeaderText="Bot">
                    <ItemTemplate>
                        <asp:Image ID="imgBot" runat="server" ImageUrl='<%# WebSiteBotHelper.GetBotImageUrl(Eval("Bot")) %>'
                            Width="32px"/>
                        <asp:Label ID="lblBotName" runat="server" Text='<%# WebSiteBotHelper.GetBotName(Eval("Bot")) %>'/>
                    </ItemTemplate>
                </asp:TemplateField>   
                <bw:BWScoreField DataField="Score" HeaderText="Total score"/>                         
                <bw:BWBotEnvironmentScoreField DataField="Bot" EnvironmentName="Maze" />
                <bw:BWBotEnvironmentScoreField DataField="Bot" EnvironmentName="Tic Tac Toe" />
                <bw:BWBotEnvironmentScoreField DataField="Bot" EnvironmentName="Pong" />
            </Columns>
        </bw:BWGridView>
    </fieldset>
</asp:Content>
