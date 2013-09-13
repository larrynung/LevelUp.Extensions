using System;
using System.Text;

static class CharExtension
{
    private static string[][] _strokesNumberData = { 
                                              new string[] { "A440", "A441" } ,                                   //1 
                                              new string[] { "A442", "A453","C940", "C944"} ,                     //2 
                                              new string[] { "A454", "A47E","C945", "C94C"} ,                     //3 
                                              new string[] { "A4A1", "A4FD","C94D", "C95C"} ,                     //4 
                                              new string[] { "A4FE", "A5DF","C95D", "C9AA"} ,                     //5 
                                              new string[] { "A5E0", "A6E9","C9AB", "C959"} ,                     //6 
                                              new string[] { "A6EA", "A8C2","CA5A", "CBB0"} ,                     //7 
                                              new string[] { "A8C3", "AB44","CBB1", "CDDC"} ,                     //8 
                                              new string[] { "AB45", "ADBB","CDDD", "D0C7","F9DA","F9DA"} ,       //9 
                                              new string[] { "ADBC", "B0AD","D0C8", "D44A"} ,                     //10
                                              new string[] { "B0AE", "B3C2","D44B", "D850"} ,                     //11
                                              new string[] { "B3C3", "B6C3","D851", "DCB0","F9DB","F9DB"} ,       //12
                                              new string[] { "B6C4", "B9AB","DCB1", "E0EF","F9D6","F9D8"} ,       //13
                                              new string[] { "B9AC", "BBF4","E0F0", "E4E5"} ,                     //14
                                              new string[] { "BBF5", "BEA6","E4E6", "E8F3","F9DC","F9DC"} ,       //15
                                              new string[] { "BEA7", "C074","E8F4", "ECB8","F9D9","F9D9"} ,       //16
                                              new string[] { "C075", "C24E","ECB9", "EFB6"} ,                     //17
                                              new string[] { "C24F", "C35E","EFB7", "F1EA"} ,                     //18
                                              new string[] { "C35F", "C454","F1EB", "F3FC"} ,                     //19
                                              new string[] { "C455", "C4D6","F3FD", "F5BF"} ,                     //20
                                              new string[] { "C3D7", "C56A","F5C0", "F6D5"} ,                     //21
                                              new string[] { "C56B", "C5C7","F6D6", "F7CF"} ,                     //22
                                              new string[] { "C5C8", "C5C7","F6D6", "F7CF"} ,                     //23
                                              new string[] { "C5F1", "C654","F8A5", "F8ED"} ,                     //24
                                              new string[] { "C655", "C664","F8E9", "F96A"} ,                     //25
                                              new string[] { "C665", "C66B","F96B", "F9A1"} ,                     //26
                                              new string[] { "C66C", "C675","F9A2", "F9B9"} ,                     //27
                                              new string[] { "C676", "C67A","F9BA", "F9C5"} ,                     //28
                                              new string[] { "C67B", "C67E","F9C6", "F9DC"} ,                     //29
                                          };

    public static int GetStrokesNumber(this char c)
    {
        String hex = BitConverter.ToString(Encoding.GetEncoding("Big5").GetBytes(new char[] { c })).Replace("-", string.Empty);
        for (int i = 0; i < _strokesNumberData.Length; ++i)
        {
            for (int j = 0; j < _strokesNumberData[i].Length; j += 2)
            {
                if (hex.CompareTo(_strokesNumberData[i][j]) >= 0 && hex.CompareTo(_strokesNumberData[i][j + 1]) <= 0)
                    return i + 1;
            }
        }
        return 0;
    }

}
