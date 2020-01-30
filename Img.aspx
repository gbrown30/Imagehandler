<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Img.aspx.cs" Inherits="WebImage.Img" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        img{
            max-height:600px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="scaled" Text="scaled" OnClick="scaled_Click"/> 
            <asp:Button runat="server" ID="text" Text="text" OnClick="text_Click"/> 
            <asp:Button runat="server" ID="transform" Text="transform" OnClick="transform_Click"/> 
        </div>
        <div>
            <span>Original:</span> <img src="Images/nature_interest.jpg" runat="server" id="pic" />

            <div runat="server" id="scaleView">
                <br /><br /><br />

                <span>Scaled:</span> <img runat="server" id="imgres" src="" /> 
            </div>

            <div runat="server" id="textView">
                <br /><br /><br />

                <span>Texted:</span> <img runat="server" id="textres" src="" />  
            </div>

            <div runat="server" id="transformView">
                <br /><br /><br /> 

                <span>Transformed:</span> <img runat="server" id="tranres" src="" /> 
            </div>

             <br /><br /><br /> 

            <div runat="server" id="display">

            </div>

        </div> 
    </form>
</body>
</html>
