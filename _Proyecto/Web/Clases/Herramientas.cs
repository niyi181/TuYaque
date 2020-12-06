using System.IO;

namespace TuYaque.Clases
{
	public class Herramientas
	{

    public static byte[] ConvertToByteArray(string varFilePath)
    {
      byte[] file;
      using (var stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read))
      {
        using (var reader = new BinaryReader(stream))
        {
          file = reader.ReadBytes((int)stream.Length);
        }
      }
      return file;
    }

  }
}