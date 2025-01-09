using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace JheyPassword.Business.Helpers;

public class CopyHelper
{
    public static void CopyToClipboard(string text)
    {
        if (string.IsNullOrEmpty(text)) return;
        Clipboard.SetTextAsync(text);
    }
}