<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.master" AutoEventWireup="true"
    CodeFile="WorldManager.aspx.cs" Inherits="Pages_WorldManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Environments</legend>
                <asp:GridView ID="grvEnvironments" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                    GridLines="Vertical" Width="100%" ShowHeader="false">
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False" >
                            <ItemTemplate>
                                <asp:Image ID="imgEnvironment" runat="server" ImageUrl='<%# WebSiteEnvironmentHelper.GetEnvironmentImageUrl(Eval("Name")) %>'
                                    Width="32px" />
                            </ItemTemplate>
                            <HeaderStyle Width="32px"/>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Name" ShowHeader="False" />
                        <asp:BoundField DataField="Description" HeaderText="Description" ShowHeader="False"/>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <br />
                <cc1:AsyncFileUpload ID="asyncUploadEnvironment" runat="server" 
                OnUploadedComplete="asyncUploadEnvironment_UploadedComplete"                    
                    UploaderStyle="Modern" UploadingBackColor="Black" />
            </fieldset>
            <br />
            <fieldset>
                <legend>Bots</legend>
                <asp:GridView ID="grvBots" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                    GridLines="Horizontal" ShowHeader="False" CssClass="Grid" DataKeyNames="Name"
                    Width="100%" OnSelectedIndexChanged="grvBots_SelectedIndexChanged" OnRowDeleting="grvBots_RowDeleting">
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
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/DeleteBotIcon.png"
                            ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#5A7042" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <br />
                <cc1:AsyncFileUpload ID="asyncUploadBot" runat="server" OnUploadedComplete="asyncUploadBot_UploadedComplete"
                    OnUploadedFileError="asyncUploadBot_UploadedFileError" CompleteBackColor="#5A7042"
                    UploaderStyle="Modern" UploadingBackColor="Black" />
                <br />
                <fieldset>
                    <legend>Abilities</legend>
                    <asp:GridView ID="grvBotAbilities" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                        GridLines="Vertical" OnRowDataBound="grvBotAbilities_RowDataBound" Width="100%"
                        OnRowDeleting="grvBotAbilities_RowDeleting">
                        <RowStyle BackColor="#F7F7DE" />
                        <Columns>
                            <asp:BoundField HeaderText="Interface">
                                <HeaderStyle Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Instance" />
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/DeleteBotIcon.png"
                                ShowDeleteButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <br />
                    <cc1:AsyncFileUpload ID="asyncUploadBotAbility" runat="server" OnUploadedComplete="asyncUploadBotAbility_UploadedComplete"
                        OnUploadedFileError="asyncUploadBotAbility_UploadedFileError" Visible="false"
                        UploaderStyle="Modern" UploadingBackColor="Black" />
                </fieldset>
            </fieldset>
            <br />
            <div id="Message" runat="server" class="Message" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
