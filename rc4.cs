using System;

class Program {
  public static void Main (string[] args) {
    byte[] key = { 0x1A, 0x2B, 0x3C, 0x4D, 0x5E, 0x6F, 0x77 };

    int N = 7;
    byte[] s = new byte[256];
    byte[] k = new byte[256];
    for (int i = 0; i < 256; i++) {
        s[i] = (byte)i;
        k[i] = key[i % N];
    }
    byte j = 0;
    byte lastI=0;
    for (int i = 0; i < 256; i++) {
        j = (byte)((j + s[i] + k[i]) % 256);
        byte temp = s[i];
        s[i] = s[j];
        s[j] = temp;
        lastI=(byte)i;
    }
    j=0;
    lastI=0;
    for(int i=0;i<1000;i++){
        lastI = (byte)((lastI + 1) % 256);
        j = (byte)((j+s[lastI]) % 256);

        byte temp = s[lastI];
        s[lastI] = s[j];
        s[j] = temp;

        byte t= (byte)((s[lastI] + s[j]) % 256);
        byte keystreamByte = s[t];
    }

    printGrid(s,lastI,j);
    }
    static void printGrid(byte[] s,byte lastI,byte lastJ){
      for(int i=0; i< s.Length;i++){
          if(i%16==0){
              Console.WriteLine();
          }
            Console.Write(s[i].ToString("X2")+" ");
      }
      Console.WriteLine();
      Console.Write("i:" + lastI.ToString() +" j: "+ lastJ.ToString());
    } 
  }