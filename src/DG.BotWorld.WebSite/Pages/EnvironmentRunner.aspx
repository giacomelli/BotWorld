<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.master" AutoEventWireup="true"
    CodeFile="EnvironmentRunner.aspx.cs" Inherits="Pages_EnvironmentRunner" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr style="vertical-align: bottom;">
            <td>
                <fieldset>
                    <legend>Available bots</legend>
                    <asp:GridView ID="grvAvailableBots" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                        GridLines="Horizontal" ShowHeader="False" CssClass="Grid" DataKeyNames="Name"
                        OnSelectedIndexChanged="grvAvailableBots_SelectedIndexChanged">
                        <RowStyle BackColor="#F7F7DE" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectImageUrl="~/Images/SelectBotIcon.png"
                                ButtonType="Image">
                                <ItemStyle Width="32px" />
                            </asp:CommandField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Image ID="imgBot" runat="server" ImageUrl='<%# WebSiteBotHelper.GetBotImageUrl(Eval("Name")) %>'
                                        Width="32px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name" ShowHeader="False" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#5A7042" ForeColor="White" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </fieldset>
            </td>
            <td rowspan="3">
                <img id="FirstStepBoard" class="Board" runat="server" />
            </td>
            <td rowspan="3">
                <img id="LastStepBoard" class="Board" runat="server" />
            </td>
        </tr>
        <tr style="vertical-align: bottom;">
            <td>
                <fieldset>
                    <legend>Selected bots</legend>
                    <asp:GridView ID="grvSelectedBots" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                        GridLines="Horizontal" ShowHeader="False" CssClass="Grid" 
                        DataKeyNames="Name" 
                        onselectedindexchanged="grvSelectedBots_SelectedIndexChanged">
                        <RowStyle BackColor="#F7F7DE" />
                        <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectImageUrl="~/Images/SelectBotIcon.png"
                                ButtonType="Image">
                                <ItemStyle Width="32px" />
                            </asp:CommandField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Image ID="imgBot" runat="server" ImageUrl='<%# WebSiteBotHelper.GetBotImageUrl(Eval("Name")) %>'
                                        Width="32px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name" ShowHeader="False" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#5A7042" ForeColor="White" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </fieldset>
            </td>
        </tr>
        <tr style="vertical-align: bottom;">
            <td>
                <asp:ImageButton ID="btnRestart" runat="server" Text="Make maze" OnClick="btnRestart_Click"
                    CssClass="Button" ImageUrl="~/Images/BuildMazeIcon.png" />
                <asp:ImageButton ID="btnPlayTurn" runat="server" Text="Start" OnClick="btnPlayTurn_Click"
                    CssClass="ButtonDisabled" ImageUrl="~/Images/RunEnvironmentIcon.png" 
                    Enabled="false" />
                <asp:ImageButton ID="btnGetMoves" runat="server" Text="Download moves" OnClick="btnGetMoves_Click"
                    ImageUrl="~/Images/DownloadMovesIcon.png" CssClass="Button" Enabled="false" />
            </td>
        </tr>
    </table>
    <div id="Message" runat="server" class="Message" />
</asp:Content>
