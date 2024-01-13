using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseholdAccountBook_Mock.MBox
{
    static class OriginMBox
    {
        /// <summary>
        /// メッセージボックスの種類判別用文字列
        /// </summary>
        const string WARNING_STR = "Warning";
        const string ERROR_STR = "Error";
        const string INFO_STR = "Info";

        public static DialogResult MBoxWarningOK(string text)
        {
            DialogResult result = MessageBox.Show(text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return result;
        }

        public static DialogResult MBoxErrorOK(string text)
        {
            DialogResult result = MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return result;
        }

        public static DialogResult MBoxInfoOK(string text)
        {
            DialogResult result = MessageBox.Show(text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return result;
        }

        public static DialogResult MBoxWarningOKCancel(string text)
        {
            DialogResult result = MessageBox.Show(text, WARNING_STR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return result;
        }

        public static DialogResult MBoxErrorOKCancel(string text)
        {
            DialogResult result = MessageBox.Show(text, ERROR_STR, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            return result;
        }

        public static DialogResult MBoxInfoOKCancel(string text)
        {
            DialogResult result = MessageBox.Show(text, INFO_STR, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            return result;
        }

        public static DialogResult MBoxWarningYesNo(string text)
        {
            DialogResult result = MessageBox.Show(text, WARNING_STR, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result;
        }

        public static DialogResult MBoxErrorYesNo(string text)
        {
            DialogResult result = MessageBox.Show(text, ERROR_STR, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            return result;
        }

        public static DialogResult MBoxInfoYesNo(string text)
        {
            DialogResult result = MessageBox.Show(text, INFO_STR, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            return result;
        }

        public static DialogResult MBoxWarningYesNoCancel(string text)
        {
            DialogResult result = MessageBox.Show(text, WARNING_STR, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            return result;
        }

        public static DialogResult MBoxErrorYesNoCancel(string text)
        {
            DialogResult result = MessageBox.Show(text, ERROR_STR, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            return result;
        }

        public static DialogResult MBoxInfoYesNoCancel(string text)
        {
            DialogResult result = MessageBox.Show(text, INFO_STR, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            return result;
        }
    }
}
