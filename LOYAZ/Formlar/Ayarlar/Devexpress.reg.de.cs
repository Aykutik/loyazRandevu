using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net.NetworkInformation;
using System.IO;
using System.Net;

namespace LOYAZ.Formlar.Ayarlar
{
    public partial class Devexpress : DevExpress.XtraEditors.XtraForm
    {
        public Devexpress()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void çözüm()
        {
            string KM1 = "";
            string KM2 = "";
            string KM3 = "";
            string KM4 = "";
            string KM5 = "";
            string KM6 = "";
            string KM7 = "";
            string KM8 = "";
            string KM9 = "";
            string KM10 = "";
            string KM11 = "";
            string KM12 = "";

            string KG1 = "";
            string KG2 = "";
            string KG3 = "";
            string KG4 = "";
            string KG5 = "";
            string KG6 = "";
            string KG7 = "";
            string KG8 = "";
            string KG9 = "";
            string KG10 = "";
            string KG11 = "";
            string KG12 = "";

            string mac = MACAdresiAl();

            lbl_macadresi.Text = mac;

            lbl_m1.Text = mac.Substring(0, 1);
            lbl_m2.Text = mac.Substring(1, 1);
            lbl_m3.Text = mac.Substring(2, 1);
            lbl_m4.Text = mac.Substring(3, 1);
            lbl_m5.Text = mac.Substring(4, 1);
            lbl_m6.Text = mac.Substring(5, 1);
            lbl_m7.Text = mac.Substring(6, 1);
            lbl_m8.Text = mac.Substring(7, 1);
            lbl_m9.Text = mac.Substring(8, 1);
            lbl_m10.Text = mac.Substring(9, 1);
            lbl_m11.Text = mac.Substring(10, 1);
            lbl_m12.Text = mac.Substring(11, 1);


            //K1
            if (lbl_m1.Text=="A" | lbl_m1.Text=="a")
            {
                KM1 = "L";
                KG1 = "DNÜ";
            }
            if (lbl_m1.Text == "B" | lbl_m1.Text == "b")
            {
                KM1 = "T";
                KG1 = "LFN";
            }
            if (lbl_m1.Text == "C" | lbl_m1.Text == "c")
            {
                KM1 = "Ş";
                KG1 = "KGO";
            }
            if (lbl_m1.Text == "Ç" | lbl_m1.Text == "ç")
            {
                KM1 = "B";
                KG1 = "1Y";
            }
            if (lbl_m1.Text == "D" | lbl_m1.Text == "d")
            {
                KM1 = "E";
                KG1 = "4U";
            }
            if (lbl_m1.Text == "E" | lbl_m1.Text == "e")
            {
                KM1 = "6";
                KG1 = "U4E";
            }
            if (lbl_m1.Text == "F" | lbl_m1.Text == "f")
            {
                KM1 = "9";
                KG1 = "Y1B";
            }
            if (lbl_m1.Text == "G" | lbl_m1.Text == "g")
            {
                KM1 = "J";
                KG1 = "BÖY";
            }
            if (lbl_m1.Text == "Ğ" | lbl_m1.Text == "ğ")
            {
                KM1 = "Ç";
                KG1 = "2V7";
            }
            if (lbl_m1.Text == "H" | lbl_m1.Text == "h")
            {
                KM1 = "Ö";
                KG1 = "ĞJS";
            }
            if (lbl_m1.Text == "I" | lbl_m1.Text == "ı")
            {
                KM1 = "K";
                KG1 = "ÇO";
            }
            if (lbl_m1.Text == "İ" | lbl_m1.Text == "i")
            {
                KM1 = "2";
                KG1 = "R8";
            }
            if (lbl_m1.Text == "J" | lbl_m1.Text == "j")
            {
                KM1 = "3";
                KG1 = "S7Ğ";
            }
            if (lbl_m1.Text == "K" | lbl_m1.Text == "k")
            {
                KM1 = "İ";
                KG1 = "APZ";
            }
            if (lbl_m1.Text == "L" | lbl_m1.Text == "l")
            {
                KM1 = "C";
                KG1 = "GUY";
            }
            if (lbl_m1.Text == "M" | lbl_m1.Text == "m")
            {
                KM1 = "N";
                KG1 = "FL";
            }
            if (lbl_m1.Text == "N" | lbl_m1.Text == "n")
            {
                KM1 = "I";
                KG1 = "9Q0";
            }
            if (lbl_m1.Text == "O" | lbl_m1.Text == "o")
            {
                KM1 = "M";
                KG1 = "EMU";
            }
            if (lbl_m1.Text == "Ö" | lbl_m1.Text == "ö")
            {
                KM1 = "V";
                KG1 = "OÇK";
            }
            if (lbl_m1.Text == "P" | lbl_m1.Text == "p")
            {
                KM1 = "Y";
                KG1 = "ÖBJ";
            }
            if (lbl_m1.Text == "Q" | lbl_m1.Text == "q")
            {
                KM1 = "F";
                KG1 = "5T4";
            }
            if (lbl_m1.Text == "R" | lbl_m1.Text == "r")
            {
                KM1 = "7";
                KG1 = "Ü3";
            }
            if (lbl_m1.Text == "S" | lbl_m1.Text == "s")
            {
                KM1 = "H";
                KG1 = "8R1";
            }
            if (lbl_m1.Text == "Ş" | lbl_m1.Text == "ş")
            {
                KM1 = "A";
                KG1 = "0Z9";
            }
            if (lbl_m1.Text == "T" | lbl_m1.Text == "t")
            {
                KM1 = "Ü";
                KG1 = "NDL";
            }
            if (lbl_m1.Text == "U" | lbl_m1.Text == "u")
            {
                KM1 = "Z";
                KG1 = "PAİ";
            }
            if (lbl_m1.Text == "Ü" | lbl_m1.Text == "ü")
            {
                KM1 = "D";
                KG1 = "3Ü6";
            }
            if (lbl_m1.Text == "V" | lbl_m1.Text == "v")
            {
                KM1 = "Ğ";
                KG1 = "7S2";
            }
            if (lbl_m1.Text == "Y" | lbl_m1.Text == "y")
            {
                KM1 = "O";
                KG1 = "GKŞ";
            }
            if (lbl_m1.Text == "Z" | lbl_m1.Text == "z")
            {
                KM1 = "8";
                KG1 = "V2Ç";
            }
            if (lbl_m1.Text == "1" )
            {
                KM1 = "P";
                KG1 = "HİR";
            }
            if (lbl_m1.Text == "2" )
            {
                KM1 = "U";
                KG1 = "MEM";
            }
            if (lbl_m1.Text == "3")
            {
                KM1 = "G";
                KG1 = "6Ş3";
            }
            if (lbl_m1.Text == "4")
            {
                KM1 = "Q";
                KG1 = "I";
            }
            if (lbl_m1.Text == "5")
            {
                KM1 = "5";
                KG1 = "T";
            }
            if (lbl_m1.Text == "6")
            {
                KM1 = "R";
                KG1 = "İHP";
            }
            if (lbl_m1.Text == "7")
            {
                KM1 = "1";
                KG1 = "Q9I";
            }
            if (lbl_m1.Text == "8")
            {
                KM1 = "4";
                KG1 = "Ş6";
            }
            if (lbl_m1.Text == "9")
            {
                KM1 = "S";
                KG1 = "ŞĞÖ";
            }
            if (lbl_m1.Text == "0")
            {
                KM1 = "0";
                KG1 = "Z";
            }
            if (lbl_m1.Text == "X" | lbl_m1.Text == "x")
            {
                KM1 = "W";
                KG1 = "HL";
            }
            if (lbl_m1.Text == "W" | lbl_m1.Text == "w")
            {
                KM1 = "X";
                KG1 = "ÖHL";
            }

            //K2
            if (lbl_m2.Text == "A" | lbl_m2.Text == "a")
            {
                KM2 = "L";
                KG2 = "DNÜ";
            }
            if (lbl_m2.Text == "B" | lbl_m2.Text == "b")
            {
                KM2 = "T";
                KG2 = "LFN";
            }
            if (lbl_m2.Text == "C" | lbl_m2.Text == "c")
            {
                KM2 = "Ş";
                KG2 = "KGO";
            }
            if (lbl_m2.Text == "Ç" | lbl_m2.Text == "ç")
            {
                KM2 = "B";
                KG2 = "1Y";
            }
            if (lbl_m2.Text == "D" | lbl_m2.Text == "d")
            {
                KM2 = "E";
                KG2 = "4U";
            }
            if (lbl_m2.Text == "E" | lbl_m2.Text == "e")
            {
                KM2 = "6";
                KG2 = "U4E";
            }
            if (lbl_m2.Text == "F" | lbl_m2.Text == "f")
            {
                KM2 = "9";
                KG2 = "Y1B";
            }
            if (lbl_m2.Text == "G" | lbl_m2.Text == "g")
            {
                KM2 = "J";
                KG2 = "BÖY";
            }
            if (lbl_m2.Text == "Ğ" | lbl_m2.Text == "ğ")
            {
                KM2 = "Ç";
                KG2 = "2V7";
            }
            if (lbl_m2.Text == "H" | lbl_m2.Text == "h")
            {
                KM2 = "Ö";
                KG2 = "ĞJS";
            }
            if (lbl_m2.Text == "I" | lbl_m2.Text == "ı")
            {
                KM2 = "K";
                KG2 = "ÇO";
            }
            if (lbl_m2.Text == "İ" | lbl_m2.Text == "i")
            {
                KM2 = "2";
                KG2 = "R8";
            }
            if (lbl_m2.Text == "J" | lbl_m2.Text == "j")
            {
                KM2 = "3";
                KG2 = "S7Ğ";
            }
            if (lbl_m2.Text == "K" | lbl_m2.Text == "k")
            {
                KM2 = "İ";
                KG2 = "APZ";
            }
            if (lbl_m2.Text == "L" | lbl_m2.Text == "l")
            {
                KM2 = "C";
                KG2 = "GUY";
            }
            if (lbl_m2.Text == "M" | lbl_m2.Text == "m")
            {
                KM2 = "N";
                KG2 = "FL";
            }
            if (lbl_m2.Text == "N" | lbl_m2.Text == "n")
            {
                KM2 = "I";
                KG2 = "9Q0";
            }
            if (lbl_m2.Text == "O" | lbl_m2.Text == "o")
            {
                KM2 = "M";
                KG2 = "EMU";
            }
            if (lbl_m2.Text == "Ö" | lbl_m2.Text == "ö")
            {
                KM2 = "V";
                KG2 = "OÇK";
            }
            if (lbl_m2.Text == "P" | lbl_m2.Text == "p")
            {
                KM2 = "Y";
                KG2 = "ÖBJ";
            }
            if (lbl_m2.Text == "Q" | lbl_m2.Text == "q")
            {
                KM2 = "F";
                KG2 = "5T4";
            }
            if (lbl_m2.Text == "R" | lbl_m2.Text == "r")
            {
                KM2 = "7";
                KG2 = "Ü3";
            }
            if (lbl_m2.Text == "S" | lbl_m2.Text == "s")
            {
                KM2 = "H";
                KG2 = "8R1";
            }
            if (lbl_m2.Text == "Ş" | lbl_m2.Text == "ş")
            {
                KM2 = "A";
                KG2 = "0Z9";
            }
            if (lbl_m2.Text == "T" | lbl_m2.Text == "t")
            {
                KM2 = "Ü";
                KG2 = "NDL";
            }
            if (lbl_m2.Text == "U" | lbl_m2.Text == "u")
            {
                KM2 = "Z";
                KG2 = "PAİ";
            }
            if (lbl_m2.Text == "Ü" | lbl_m2.Text == "ü")
            {
                KM2 = "D";
                KG2 = "3Ü6";
            }
            if (lbl_m2.Text == "V" | lbl_m2.Text == "v")
            {
                KM2 = "Ğ";
                KG2 = "7S2";
            }
            if (lbl_m2.Text == "Y" | lbl_m2.Text == "y")
            {
                KM2 = "O";
                KG2 = "GKŞ";
            }
            if (lbl_m2.Text == "Z" | lbl_m2.Text == "z")
            {
                KM2 = "8";
                KG2 = "V2Ç";
            }
            if (lbl_m2.Text == "1")
            {
                KM2 = "P";
                KG2 = "HİR";
            }
            if (lbl_m2.Text == "2")
            {
                KM2 = "U";
                KG2 = "MEM";
            }
            if (lbl_m2.Text == "3")
            {
                KM2 = "G";
                KG2 = "6Ş3";
            }
            if (lbl_m2.Text == "4")
            {
                KM2 = "Q";
                KG2 = "I";
            }
            if (lbl_m2.Text == "5")
            {
                KM2 = "5";
                KG2 = "T";
            }
            if (lbl_m2.Text == "6")
            {
                KM2 = "R";
                KG2 = "İHP";
            }
            if (lbl_m2.Text == "7")
            {
                KM2 = "1";
                KG2 = "Q9I";
            }
            if (lbl_m2.Text == "8")
            {
                KM2 = "4";
                KG2 = "Ş6";
            }
            if (lbl_m2.Text == "9")
            {
                KM2 = "S";
                KG2 = "ŞĞÖ";
            }
            if (lbl_m2.Text == "0")
            {
                KM2 = "0";
                KG2 = "Z";
            }
            if (lbl_m2.Text == "X" | lbl_m2.Text == "x")
            {
                KM2 = "W";
                KG2 = "HL";
            }
            if (lbl_m2.Text == "W" | lbl_m2.Text == "w")
            {
                KM2 = "X";
                KG2 = "ÖHL";
            }

            //K3
            if (lbl_m3.Text == "A" | lbl_m3.Text == "a")
            {
                KM3 = "L";
                KG3 = "DNÜ";
            }
            if (lbl_m3.Text == "B" | lbl_m3.Text == "b")
            {
                KM3 = "T";
                KG3 = "LFN";
            }
            if (lbl_m3.Text == "C" | lbl_m3.Text == "c")
            {
                KM3 = "Ş";
                KG3 = "KGO";
            }
            if (lbl_m3.Text == "Ç" | lbl_m3.Text == "ç")
            {
                KM3 = "B";
                KG3 = "1Y";
            }
            if (lbl_m3.Text == "D" | lbl_m3.Text == "d")
            {
                KM3 = "E";
                KG3 = "4U";
            }
            if (lbl_m3.Text == "E" | lbl_m3.Text == "e")
            {
                KM3 = "6";
                KG3 = "U4E";
            }
            if (lbl_m3.Text == "F" | lbl_m3.Text == "f")
            {
                KM3 = "9";
                KG3 = "Y1B";
            }
            if (lbl_m3.Text == "G" | lbl_m3.Text == "g")
            {
                KM3 = "J";
                KG3 = "BÖY";
            }
            if (lbl_m3.Text == "Ğ" | lbl_m3.Text == "ğ")
            {
                KM3 = "Ç";
                KG3 = "2V7";
            }
            if (lbl_m3.Text == "H" | lbl_m3.Text == "h")
            {
                KM3 = "Ö";
                KG3 = "ĞJS";
            }
            if (lbl_m3.Text == "I" | lbl_m3.Text == "ı")
            {
                KM3 = "K";
                KG3 = "ÇO";
            }
            if (lbl_m3.Text == "İ" | lbl_m3.Text == "i")
            {
                KM3 = "2";
                KG3 = "R8";
            }
            if (lbl_m3.Text == "J" | lbl_m3.Text == "j")
            {
                KM3 = "3";
                KG3 = "S7Ğ";
            }
            if (lbl_m3.Text == "K" | lbl_m3.Text == "k")
            {
                KM3 = "İ";
                KG3 = "APZ";
            }
            if (lbl_m3.Text == "L" | lbl_m3.Text == "l")
            {
                KM3 = "C";
                KG3 = "GUY";
            }
            if (lbl_m3.Text == "M" | lbl_m3.Text == "m")
            {
                KM3 = "N";
                KG3 = "FL";
            }
            if (lbl_m3.Text == "N" | lbl_m3.Text == "n")
            {
                KM3 = "I";
                KG3 = "9Q0";
            }
            if (lbl_m3.Text == "O" | lbl_m3.Text == "o")
            {
                KM3 = "M";
                KG3 = "EMU";
            }
            if (lbl_m3.Text == "Ö" | lbl_m3.Text == "ö")
            {
                KM3 = "V";
                KG3 = "OÇK";
            }
            if (lbl_m3.Text == "P" | lbl_m3.Text == "p")
            {
                KM3 = "Y";
                KG3 = "ÖBJ";
            }
            if (lbl_m3.Text == "Q" | lbl_m3.Text == "q")
            {
                KM3 = "F";
                KG3 = "5T4";
            }
            if (lbl_m3.Text == "R" | lbl_m3.Text == "r")
            {
                KM3 = "7";
                KG3 = "Ü3";
            }
            if (lbl_m3.Text == "S" | lbl_m3.Text == "s")
            {
                KM3 = "H";
                KG3 = "8R1";
            }
            if (lbl_m3.Text == "Ş" | lbl_m3.Text == "ş")
            {
                KM3 = "A";
                KG3 = "0Z9";
            }
            if (lbl_m3.Text == "T" | lbl_m3.Text == "t")
            {
                KM3 = "Ü";
                KG3 = "NDL";
            }
            if (lbl_m3.Text == "U" | lbl_m3.Text == "u")
            {
                KM3 = "Z";
                KG3 = "PAİ";
            }
            if (lbl_m3.Text == "Ü" | lbl_m3.Text == "ü")
            {
                KM3 = "D";
                KG3 = "3Ü6";
            }
            if (lbl_m3.Text == "V" | lbl_m3.Text == "v")
            {
                KM3 = "Ğ";
                KG3 = "7S2";
            }
            if (lbl_m3.Text == "Y" | lbl_m3.Text == "y")
            {
                KM3 = "O";
                KG3 = "GKŞ";
            }
            if (lbl_m3.Text == "Z" | lbl_m3.Text == "z")
            {
                KM3 = "8";
                KG3 = "V2Ç";
            }
            if (lbl_m3.Text == "1")
            {
                KM3 = "P";
                KG3 = "HİR";
            }
            if (lbl_m3.Text == "2")
            {
                KM3 = "U";
                KG3 = "MEM";
            }
            if (lbl_m3.Text == "3")
            {
                KM3 = "G";
                KG3 = "6Ş3";
            }
            if (lbl_m3.Text == "4")
            {
                KM3 = "Q";
                KG3 = "I";
            }
            if (lbl_m3.Text == "5")
            {
                KM3 = "5";
                KG3 = "T";
            }
            if (lbl_m3.Text == "6")
            {
                KM3 = "R";
                KG3 = "İHP";
            }
            if (lbl_m3.Text == "7")
            {
                KM3 = "1";
                KG3 = "Q9I";
            }
            if (lbl_m3.Text == "8")
            {
                KM3 = "4";
                KG3 = "Ş6";
            }
            if (lbl_m3.Text == "9")
            {
                KM3 = "S";
                KG3 = "ŞĞÖ";
            }
            if (lbl_m3.Text == "0")
            {
                KM3 = "0";
                KG3 = "Z";
            }
            if (lbl_m3.Text == "X" | lbl_m3.Text == "x")
            {
                KM3 = "W";
                KG3 = "HL";
            }
            if (lbl_m3.Text == "W" | lbl_m3.Text == "w")
            {
                KM3 = "X";
                KG3 = "ÖHL";
            }


            //K4
            if (lbl_m4.Text == "A" | lbl_m4.Text == "a")
            {
                KM4 = "L";
                KG4 = "DNÜ";
            }
            if (lbl_m4.Text == "B" | lbl_m4.Text == "b")
            {
                KM4 = "T";
                KG4 = "LFN";
            }
            if (lbl_m4.Text == "C" | lbl_m4.Text == "c")
            {
                KM4 = "Ş";
                KG4 = "KGO";
            }
            if (lbl_m4.Text == "Ç" | lbl_m4.Text == "ç")
            {
                KM4 = "B";
                KG4 = "1Y";
            }
            if (lbl_m4.Text == "D" | lbl_m4.Text == "d")
            {
                KM4 = "E";
                KG4 = "4U";
            }
            if (lbl_m4.Text == "E" | lbl_m4.Text == "e")
            {
                KM4 = "6";
                KG4 = "U4E";
            }
            if (lbl_m4.Text == "F" | lbl_m4.Text == "f")
            {
                KM4 = "9";
                KG4 = "Y1B";
            }
            if (lbl_m4.Text == "G" | lbl_m4.Text == "g")
            {
                KM4 = "J";
                KG4 = "BÖY";
            }
            if (lbl_m4.Text == "Ğ" | lbl_m4.Text == "ğ")
            {
                KM4 = "Ç";
                KG4 = "2V7";
            }
            if (lbl_m4.Text == "H" | lbl_m4.Text == "h")
            {
                KM4 = "Ö";
                KG4 = "ĞJS";
            }
            if (lbl_m4.Text == "I" | lbl_m4.Text == "ı")
            {
                KM4 = "K";
                KG4 = "ÇO";
            }
            if (lbl_m4.Text == "İ" | lbl_m4.Text == "i")
            {
                KM4 = "2";
                KG4 = "R8";
            }
            if (lbl_m4.Text == "J" | lbl_m4.Text == "j")
            {
                KM4 = "3";
                KG4 = "S7Ğ";
            }
            if (lbl_m4.Text == "K" | lbl_m4.Text == "k")
            {
                KM4 = "İ";
                KG4 = "APZ";
            }
            if (lbl_m4.Text == "L" | lbl_m4.Text == "l")
            {
                KM4 = "C";
                KG4 = "GUY";
            }
            if (lbl_m4.Text == "M" | lbl_m4.Text == "m")
            {
                KM4 = "N";
                KG4 = "FL";
            }
            if (lbl_m4.Text == "N" | lbl_m4.Text == "n")
            {
                KM4 = "I";
                KG4 = "9Q0";
            }
            if (lbl_m4.Text == "O" | lbl_m4.Text == "o")
            {
                KM4 = "M";
                KG4 = "EMU";
            }
            if (lbl_m4.Text == "Ö" | lbl_m4.Text == "ö")
            {
                KM4 = "V";
                KG4 = "OÇK";
            }
            if (lbl_m4.Text == "P" | lbl_m4.Text == "p")
            {
                KM4 = "Y";
                KG4 = "ÖBJ";
            }
            if (lbl_m4.Text == "Q" | lbl_m4.Text == "q")
            {
                KM4 = "F";
                KG4 = "5T4";
            }
            if (lbl_m4.Text == "R" | lbl_m4.Text == "r")
            {
                KM4 = "7";
                KG4 = "Ü3";
            }
            if (lbl_m4.Text == "S" | lbl_m4.Text == "s")
            {
                KM4 = "H";
                KG4 = "8R1";
            }
            if (lbl_m4.Text == "Ş" | lbl_m4.Text == "ş")
            {
                KM4 = "A";
                KG4 = "0Z9";
            }
            if (lbl_m4.Text == "T" | lbl_m4.Text == "t")
            {
                KM4 = "Ü";
                KG4 = "NDL";
            }
            if (lbl_m4.Text == "U" | lbl_m4.Text == "u")
            {
                KM4 = "Z";
                KG4 = "PAİ";
            }
            if (lbl_m4.Text == "Ü" | lbl_m4.Text == "ü")
            {
                KM4 = "D";
                KG4 = "3Ü6";
            }
            if (lbl_m4.Text == "V" | lbl_m4.Text == "v")
            {
                KM4 = "Ğ";
                KG4 = "7S2";
            }
            if (lbl_m4.Text == "Y" | lbl_m4.Text == "y")
            {
                KM4 = "O";
                KG4 = "GKŞ";
            }
            if (lbl_m4.Text == "Z" | lbl_m4.Text == "z")
            {
                KM4 = "8";
                KG4 = "V2Ç";
            }
            if (lbl_m4.Text == "1")
            {
                KM4 = "P";
                KG4 = "HİR";
            }
            if (lbl_m4.Text == "2")
            {
                KM4 = "U";
                KG4 = "MEM";
            }
            if (lbl_m4.Text == "3")
            {
                KM4 = "G";
                KG4 = "6Ş3";
            }
            if (lbl_m4.Text == "4")
            {
                KM4 = "Q";
                KG4 = "I";
            }
            if (lbl_m4.Text == "5")
            {
                KM4 = "5";
                KG4 = "T";
            }
            if (lbl_m4.Text == "6")
            {
                KM4 = "R";
                KG4 = "İHP";
            }
            if (lbl_m4.Text == "7")
            {
                KM4 = "1";
                KG4 = "Q9I";
            }
            if (lbl_m4.Text == "8")
            {
                KM4 = "4";
                KG4 = "Ş6";
            }
            if (lbl_m4.Text == "9")
            {
                KM4 = "S";
                KG4 = "ŞĞÖ";
            }
            if (lbl_m4.Text == "0")
            {
                KM4 = "0";
                KG4 = "Z";
            }
            if (lbl_m4.Text == "X" | lbl_m4.Text == "x")
            {
                KM4 = "W";
                KG4 = "HL";
            }
            if (lbl_m4.Text == "W" | lbl_m4.Text == "w")
            {
                KM4 = "X";
                KG4 = "ÖHL";
            }


            //K5
            if (lbl_m5.Text == "A" | lbl_m5.Text == "a")
            {
                KM5 = "L";
                KG5 = "DNÜ";
            }
            if (lbl_m5.Text == "B" | lbl_m5.Text == "b")
            {
                KM5 = "T";
                KG5 = "LFN";
            }
            if (lbl_m5.Text == "C" | lbl_m5.Text == "c")
            {
                KM5 = "Ş";
                KG5 = "KGO";
            }
            if (lbl_m5.Text == "Ç" | lbl_m5.Text == "ç")
            {
                KM5 = "B";
                KG5 = "1Y";
            }
            if (lbl_m5.Text == "D" | lbl_m5.Text == "d")
            {
                KM5 = "E";
                KG5 = "4U";
            }
            if (lbl_m5.Text == "E" | lbl_m5.Text == "e")
            {
                KM5 = "6";
                KG5 = "U4E";
            }
            if (lbl_m5.Text == "F" | lbl_m5.Text == "f")
            {
                KM5 = "9";
                KG5 = "Y1B";
            }
            if (lbl_m5.Text == "G" | lbl_m5.Text == "g")
            {
                KM5 = "J";
                KG5 = "BÖY";
            }
            if (lbl_m5.Text == "Ğ" | lbl_m5.Text == "ğ")
            {
                KM5 = "Ç";
                KG5 = "2V7";
            }
            if (lbl_m5.Text == "H" | lbl_m5.Text == "h")
            {
                KM5 = "Ö";
                KG5 = "ĞJS";
            }
            if (lbl_m5.Text == "I" | lbl_m5.Text == "ı")
            {
                KM5 = "K";
                KG5 = "ÇO";
            }
            if (lbl_m5.Text == "İ" | lbl_m5.Text == "i")
            {
                KM5 = "2";
                KG5 = "R8";
            }
            if (lbl_m5.Text == "J" | lbl_m5.Text == "j")
            {
                KM5 = "3";
                KG5 = "S7Ğ";
            }
            if (lbl_m5.Text == "K" | lbl_m5.Text == "k")
            {
                KM5 = "İ";
                KG5 = "APZ";
            }
            if (lbl_m5.Text == "L" | lbl_m5.Text == "l")
            {
                KM5 = "C";
                KG5 = "GUY";
            }
            if (lbl_m5.Text == "M" | lbl_m5.Text == "m")
            {
                KM5 = "N";
                KG5 = "FL";
            }
            if (lbl_m5.Text == "N" | lbl_m5.Text == "n")
            {
                KM5 = "I";
                KG5 = "9Q0";
            }
            if (lbl_m5.Text == "O" | lbl_m5.Text == "o")
            {
                KM5 = "M";
                KG5 = "EMU";
            }
            if (lbl_m5.Text == "Ö" | lbl_m5.Text == "ö")
            {
                KM5 = "V";
                KG5 = "OÇK";
            }
            if (lbl_m5.Text == "P" | lbl_m5.Text == "p")
            {
                KM5 = "Y";
                KG5 = "ÖBJ";
            }
            if (lbl_m5.Text == "Q" | lbl_m5.Text == "q")
            {
                KM5 = "F";
                KG5 = "5T4";
            }
            if (lbl_m5.Text == "R" | lbl_m5.Text == "r")
            {
                KM5 = "7";
                KG5 = "Ü3";
            }
            if (lbl_m5.Text == "S" | lbl_m5.Text == "s")
            {
                KM5 = "H";
                KG5 = "8R1";
            }
            if (lbl_m5.Text == "Ş" | lbl_m5.Text == "ş")
            {
                KM5 = "A";
                KG5 = "0Z9";
            }
            if (lbl_m5.Text == "T" | lbl_m5.Text == "t")
            {
                KM5 = "Ü";
                KG5 = "NDL";
            }
            if (lbl_m5.Text == "U" | lbl_m5.Text == "u")
            {
                KM5 = "Z";
                KG5 = "PAİ";
            }
            if (lbl_m5.Text == "Ü" | lbl_m5.Text == "ü")
            {
                KM5 = "D";
                KG5 = "3Ü6";
            }
            if (lbl_m5.Text == "V" | lbl_m5.Text == "v")
            {
                KM5 = "Ğ";
                KG5 = "7S2";
            }
            if (lbl_m5.Text == "Y" | lbl_m5.Text == "y")
            {
                KM5 = "O";
                KG5 = "GKŞ";
            }
            if (lbl_m5.Text == "Z" | lbl_m5.Text == "z")
            {
                KM5 = "8";
                KG5 = "V2Ç";
            }
            if (lbl_m5.Text == "1")
            {
                KM5 = "P";
                KG5 = "HİR";
            }
            if (lbl_m5.Text == "2")
            {
                KM5 = "U";
                KG5 = "MEM";
            }
            if (lbl_m5.Text == "3")
            {
                KM5 = "G";
                KG5 = "6Ş3";
            }
            if (lbl_m5.Text == "4")
            {
                KM5 = "Q";
                KG5 = "I";
            }
            if (lbl_m5.Text == "5")
            {
                KM5 = "5";
                KG5 = "T";
            }
            if (lbl_m5.Text == "6")
            {
                KM5 = "R";
                KG5 = "İHP";
            }
            if (lbl_m5.Text == "7")
            {
                KM5 = "1";
                KG5 = "Q9I";
            }
            if (lbl_m5.Text == "8")
            {
                KM5 = "4";
                KG5 = "Ş6";
            }
            if (lbl_m5.Text == "9")
            {
                KM5 = "S";
                KG5 = "ŞĞÖ";
            }
            if (lbl_m5.Text == "0")
            {
                KM5 = "0";
                KG5 = "Z";
            }
            if (lbl_m5.Text == "X" | lbl_m5.Text == "x")
            {
                KM5 = "W";
                KG5 = "HL";
            }
            if (lbl_m5.Text == "W" | lbl_m5.Text == "w")
            {
                KM5 = "X";
                KG5 = "ÖHL";
            }

            //K6
            if (lbl_m6.Text == "A" | lbl_m6.Text == "a")
            {
                KM6 = "L";
                KG6 = "DNÜ";
            }
            if (lbl_m6.Text == "B" | lbl_m6.Text == "b")
            {
                KM6 = "T";
                KG6 = "LFN";
            }
            if (lbl_m6.Text == "C" | lbl_m6.Text == "c")
            {
                KM6 = "Ş";
                KG6 = "KGO";
            }
            if (lbl_m6.Text == "Ç" | lbl_m6.Text == "ç")
            {
                KM6 = "B";
                KG6 = "1Y";
            }
            if (lbl_m6.Text == "D" | lbl_m6.Text == "d")
            {
                KM6 = "E";
                KG6 = "4U";
            }
            if (lbl_m6.Text == "E" | lbl_m6.Text == "e")
            {
                KM6 = "6";
                KG6 = "U4E";
            }
            if (lbl_m6.Text == "F" | lbl_m6.Text == "f")
            {
                KM6 = "9";
                KG6 = "Y1B";
            }
            if (lbl_m6.Text == "G" | lbl_m6.Text == "g")
            {
                KM6 = "J";
                KG6 = "BÖY";
            }
            if (lbl_m6.Text == "Ğ" | lbl_m6.Text == "ğ")
            {
                KM6 = "Ç";
                KG6 = "2V7";
            }
            if (lbl_m6.Text == "H" | lbl_m6.Text == "h")
            {
                KM6 = "Ö";
                KG6 = "ĞJS";
            }
            if (lbl_m6.Text == "I" | lbl_m6.Text == "ı")
            {
                KM6 = "K";
                KG6 = "ÇO";
            }
            if (lbl_m6.Text == "İ" | lbl_m6.Text == "i")
            {
                KM6 = "2";
                KG6 = "R8";
            }
            if (lbl_m6.Text == "J" | lbl_m6.Text == "j")
            {
                KM6 = "3";
                KG6 = "S7Ğ";
            }
            if (lbl_m6.Text == "K" | lbl_m6.Text == "k")
            {
                KM6 = "İ";
                KG6 = "APZ";
            }
            if (lbl_m6.Text == "L" | lbl_m6.Text == "l")
            {
                KM6 = "C";
                KG6 = "GUY";
            }
            if (lbl_m6.Text == "M" | lbl_m6.Text == "m")
            {
                KM6 = "N";
                KG6 = "FL";
            }
            if (lbl_m6.Text == "N" | lbl_m6.Text == "n")
            {
                KM6 = "I";
                KG6 = "9Q0";
            }
            if (lbl_m6.Text == "O" | lbl_m6.Text == "o")
            {
                KM6 = "M";
                KG6 = "EMU";
            }
            if (lbl_m6.Text == "Ö" | lbl_m6.Text == "ö")
            {
                KM6 = "V";
                KG6 = "OÇK";
            }
            if (lbl_m6.Text == "P" | lbl_m6.Text == "p")
            {
                KM6 = "Y";
                KG6 = "ÖBJ";
            }
            if (lbl_m6.Text == "Q" | lbl_m6.Text == "q")
            {
                KM6 = "F";
                KG6 = "5T4";
            }
            if (lbl_m6.Text == "R" | lbl_m6.Text == "r")
            {
                KM6 = "7";
                KG6 = "Ü3";
            }
            if (lbl_m6.Text == "S" | lbl_m6.Text == "s")
            {
                KM6 = "H";
                KG6 = "8R1";
            }
            if (lbl_m6.Text == "Ş" | lbl_m6.Text == "ş")
            {
                KM6 = "A";
                KG6 = "0Z9";
            }
            if (lbl_m6.Text == "T" | lbl_m6.Text == "t")
            {
                KM6 = "Ü";
                KG6 = "NDL";
            }
            if (lbl_m6.Text == "U" | lbl_m6.Text == "u")
            {
                KM6 = "Z";
                KG6 = "PAİ";
            }
            if (lbl_m6.Text == "Ü" | lbl_m6.Text == "ü")
            {
                KM6 = "D";
                KG6 = "3Ü6";
            }
            if (lbl_m6.Text == "V" | lbl_m6.Text == "v")
            {
                KM6 = "Ğ";
                KG6 = "7S2";
            }
            if (lbl_m6.Text == "Y" | lbl_m6.Text == "y")
            {
                KM6 = "O";
                KG6 = "GKŞ";
            }
            if (lbl_m6.Text == "Z" | lbl_m6.Text == "z")
            {
                KM6 = "8";
                KG6 = "V2Ç";
            }
            if (lbl_m6.Text == "1")
            {
                KM6 = "P";
                KG6 = "HİR";
            }
            if (lbl_m6.Text == "2")
            {
                KM6 = "U";
                KG6 = "MEM";
            }
            if (lbl_m6.Text == "3")
            {
                KM6 = "G";
                KG6 = "6Ş3";
            }
            if (lbl_m6.Text == "4")
            {
                KM6 = "Q";
                KG6 = "I";
            }
            if (lbl_m6.Text == "5")
            {
                KM6 = "5";
                KG6 = "T";
            }
            if (lbl_m6.Text == "6")
            {
                KM6 = "R";
                KG6 = "İHP";
            }
            if (lbl_m6.Text == "7")
            {
                KM6 = "1";
                KG6 = "Q9I";
            }
            if (lbl_m6.Text == "8")
            {
                KM6 = "4";
                KG6 = "Ş6";
            }
            if (lbl_m6.Text == "9")
            {
                KM6 = "S";
                KG6 = "ŞĞÖ";
            }
            if (lbl_m6.Text == "0")
            {
                KM6 = "0";
                KG6 = "Z";
            }
            if (lbl_m6.Text == "X" | lbl_m6.Text == "x")
            {
                KM6 = "W";
                KG6 = "HL";
            }
            if (lbl_m6.Text == "W" | lbl_m6.Text == "w")
            {
                KM6 = "X";
                KG6 = "ÖHL";
            }


            //K7
            if (lbl_m7.Text == "A" | lbl_m7.Text == "a")
            {
                KM7 = "L";
                KG7 = "DNÜ";
            }
            if (lbl_m7.Text == "B" | lbl_m7.Text == "b")
            {
                KM7 = "T";
                KG7 = "LFN";
            }
            if (lbl_m7.Text == "C" | lbl_m7.Text == "c")
            {
                KM7 = "Ş";
                KG7 = "KGO";
            }
            if (lbl_m7.Text == "Ç" | lbl_m7.Text == "ç")
            {
                KM7 = "B";
                KG7 = "1Y";
            }
            if (lbl_m7.Text == "D" | lbl_m7.Text == "d")
            {
                KM7 = "E";
                KG7 = "4U";
            }
            if (lbl_m7.Text == "E" | lbl_m7.Text == "e")
            {
                KM7 = "6";
                KG7 = "U4E";
            }
            if (lbl_m7.Text == "F" | lbl_m7.Text == "f")
            {
                KM7 = "9";
                KG7 = "Y1B";
            }
            if (lbl_m7.Text == "G" | lbl_m7.Text == "g")
            {
                KM7 = "J";
                KG7 = "BÖY";
            }
            if (lbl_m7.Text == "Ğ" | lbl_m7.Text == "ğ")
            {
                KM7 = "Ç";
                KG7 = "2V7";
            }
            if (lbl_m7.Text == "H" | lbl_m7.Text == "h")
            {
                KM7 = "Ö";
                KG7 = "ĞJS";
            }
            if (lbl_m7.Text == "I" | lbl_m7.Text == "ı")
            {
                KM7 = "K";
                KG7 = "ÇO";
            }
            if (lbl_m7.Text == "İ" | lbl_m7.Text == "i")
            {
                KM7 = "2";
                KG7 = "R8";
            }
            if (lbl_m7.Text == "J" | lbl_m7.Text == "j")
            {
                KM7 = "3";
                KG7 = "S7Ğ";
            }
            if (lbl_m7.Text == "K" | lbl_m7.Text == "k")
            {
                KM7 = "İ";
                KG7 = "APZ";
            }
            if (lbl_m7.Text == "L" | lbl_m7.Text == "l")
            {
                KM7 = "C";
                KG7 = "GUY";
            }
            if (lbl_m7.Text == "M" | lbl_m7.Text == "m")
            {
                KM7 = "N";
                KG7 = "FL";
            }
            if (lbl_m7.Text == "N" | lbl_m7.Text == "n")
            {
                KM7 = "I";
                KG7 = "9Q0";
            }
            if (lbl_m7.Text == "O" | lbl_m7.Text == "o")
            {
                KM7 = "M";
                KG7 = "EMU";
            }
            if (lbl_m7.Text == "Ö" | lbl_m7.Text == "ö")
            {
                KM7 = "V";
                KG7 = "OÇK";
            }
            if (lbl_m7.Text == "P" | lbl_m7.Text == "p")
            {
                KM7 = "Y";
                KG7 = "ÖBJ";
            }
            if (lbl_m7.Text == "Q" | lbl_m7.Text == "q")
            {
                KM7 = "F";
                KG7 = "5T4";
            }
            if (lbl_m7.Text == "R" | lbl_m7.Text == "r")
            {
                KM7 = "7";
                KG7 = "Ü3";
            }
            if (lbl_m7.Text == "S" | lbl_m7.Text == "s")
            {
                KM7 = "H";
                KG7 = "8R1";
            }
            if (lbl_m7.Text == "Ş" | lbl_m7.Text == "ş")
            {
                KM7 = "A";
                KG7 = "0Z9";
            }
            if (lbl_m7.Text == "T" | lbl_m7.Text == "t")
            {
                KM7 = "Ü";
                KG7 = "NDL";
            }
            if (lbl_m7.Text == "U" | lbl_m7.Text == "u")
            {
                KM7 = "Z";
                KG7 = "PAİ";
            }
            if (lbl_m7.Text == "Ü" | lbl_m7.Text == "ü")
            {
                KM7 = "D";
                KG7 = "3Ü6";
            }
            if (lbl_m7.Text == "V" | lbl_m7.Text == "v")
            {
                KM7 = "Ğ";
                KG7 = "7S2";
            }
            if (lbl_m7.Text == "Y" | lbl_m7.Text == "y")
            {
                KM7 = "O";
                KG7 = "GKŞ";
            }
            if (lbl_m7.Text == "Z" | lbl_m7.Text == "z")
            {
                KM7 = "8";
                KG7 = "V2Ç";
            }
            if (lbl_m7.Text == "1")
            {
                KM7 = "P";
                KG7 = "HİR";
            }
            if (lbl_m7.Text == "2")
            {
                KM7 = "U";
                KG7 = "MEM";
            }
            if (lbl_m7.Text == "3")
            {
                KM7 = "G";
                KG7 = "6Ş3";
            }
            if (lbl_m7.Text == "4")
            {
                KM7 = "Q";
                KG7 = "I";
            }
            if (lbl_m7.Text == "5")
            {
                KM7 = "5";
                KG7 = "T";
            }
            if (lbl_m7.Text == "6")
            {
                KM7 = "R";
                KG7 = "İHP";
            }
            if (lbl_m7.Text == "7")
            {
                KM7 = "1";
                KG7 = "Q9I";
            }
            if (lbl_m7.Text == "8")
            {
                KM7 = "4";
                KG7 = "Ş6";
            }
            if (lbl_m7.Text == "9")
            {
                KM7 = "S";
                KG7 = "ŞĞÖ";
            }
            if (lbl_m7.Text == "0")
            {
                KM7 = "0";
                KG7 = "Z";
            }
            if (lbl_m7.Text == "X" | lbl_m7.Text == "x")
            {
                KM7 = "W";
                KG7 = "HL";
            }
            if (lbl_m7.Text == "W" | lbl_m7.Text == "w")
            {
                KM7 = "X";
                KG7 = "ÖHL";
            }


            //K8
            if (lbl_m8.Text == "A" | lbl_m8.Text == "a")
            {
                KM8 = "L";
                KG8 = "DNÜ";
            }
            if (lbl_m8.Text == "B" | lbl_m8.Text == "b")
            {
                KM8 = "T";
                KG8 = "LFN";
            }
            if (lbl_m8.Text == "C" | lbl_m8.Text == "c")
            {
                KM8 = "Ş";
                KG8 = "KGO";
            }
            if (lbl_m8.Text == "Ç" | lbl_m8.Text == "ç")
            {
                KM8 = "B";
                KG8 = "1Y";
            }
            if (lbl_m8.Text == "D" | lbl_m8.Text == "d")
            {
                KM8 = "E";
                KG8 = "4U";
            }
            if (lbl_m8.Text == "E" | lbl_m8.Text == "e")
            {
                KM8 = "6";
                KG8 = "U4E";
            }
            if (lbl_m8.Text == "F" | lbl_m8.Text == "f")
            {
                KM8 = "9";
                KG8 = "Y1B";
            }
            if (lbl_m8.Text == "G" | lbl_m8.Text == "g")
            {
                KM8 = "J";
                KG8 = "BÖY";
            }
            if (lbl_m8.Text == "Ğ" | lbl_m8.Text == "ğ")
            {
                KM8 = "Ç";
                KG8 = "2V7";
            }
            if (lbl_m8.Text == "H" | lbl_m8.Text == "h")
            {
                KM8 = "Ö";
                KG8 = "ĞJS";
            }
            if (lbl_m8.Text == "I" | lbl_m8.Text == "ı")
            {
                KM8 = "K";
                KG8 = "ÇO";
            }
            if (lbl_m8.Text == "İ" | lbl_m8.Text == "i")
            {
                KM8 = "2";
                KG8 = "R8";
            }
            if (lbl_m8.Text == "J" | lbl_m8.Text == "j")
            {
                KM8 = "3";
                KG8 = "S7Ğ";
            }
            if (lbl_m8.Text == "K" | lbl_m8.Text == "k")
            {
                KM8 = "İ";
                KG8 = "APZ";
            }
            if (lbl_m8.Text == "L" | lbl_m8.Text == "l")
            {
                KM8 = "C";
                KG8 = "GUY";
            }
            if (lbl_m8.Text == "M" | lbl_m8.Text == "m")
            {
                KM8 = "N";
                KG8 = "FL";
            }
            if (lbl_m8.Text == "N" | lbl_m8.Text == "n")
            {
                KM8 = "I";
                KG8 = "9Q0";
            }
            if (lbl_m8.Text == "O" | lbl_m8.Text == "o")
            {
                KM8 = "M";
                KG8 = "EMU";
            }
            if (lbl_m8.Text == "Ö" | lbl_m8.Text == "ö")
            {
                KM8 = "V";
                KG8 = "OÇK";
            }
            if (lbl_m8.Text == "P" | lbl_m8.Text == "p")
            {
                KM8 = "Y";
                KG8 = "ÖBJ";
            }
            if (lbl_m8.Text == "Q" | lbl_m8.Text == "q")
            {
                KM8 = "F";
                KG8 = "5T4";
            }
            if (lbl_m8.Text == "R" | lbl_m8.Text == "r")
            {
                KM8 = "7";
                KG8 = "Ü3";
            }
            if (lbl_m8.Text == "S" | lbl_m8.Text == "s")
            {
                KM8 = "H";
                KG8 = "8R1";
            }
            if (lbl_m8.Text == "Ş" | lbl_m8.Text == "ş")
            {
                KM8 = "A";
                KG8 = "0Z9";
            }
            if (lbl_m8.Text == "T" | lbl_m8.Text == "t")
            {
                KM8 = "Ü";
                KG8 = "NDL";
            }
            if (lbl_m8.Text == "U" | lbl_m8.Text == "u")
            {
                KM8 = "Z";
                KG8 = "PAİ";
            }
            if (lbl_m8.Text == "Ü" | lbl_m8.Text == "ü")
            {
                KM8 = "D";
                KG8 = "3Ü6";
            }
            if (lbl_m8.Text == "V" | lbl_m8.Text == "v")
            {
                KM8 = "Ğ";
                KG8 = "7S2";
            }
            if (lbl_m8.Text == "Y" | lbl_m8.Text == "y")
            {
                KM8 = "O";
                KG8 = "GKŞ";
            }
            if (lbl_m8.Text == "Z" | lbl_m8.Text == "z")
            {
                KM8 = "8";
                KG8 = "V2Ç";
            }
            if (lbl_m8.Text == "1")
            {
                KM8 = "P";
                KG8 = "HİR";
            }
            if (lbl_m8.Text == "2")
            {
                KM8 = "U";
                KG8 = "MEM";
            }
            if (lbl_m8.Text == "3")
            {
                KM8 = "G";
                KG8 = "6Ş3";
            }
            if (lbl_m8.Text == "4")
            {
                KM8 = "Q";
                KG8 = "I";
            }
            if (lbl_m8.Text == "5")
            {
                KM8 = "5";
                KG8 = "T";
            }
            if (lbl_m8.Text == "6")
            {
                KM8 = "R";
                KG8 = "İHP";
            }
            if (lbl_m8.Text == "7")
            {
                KM8 = "1";
                KG8 = "Q9I";
            }
            if (lbl_m8.Text == "8")
            {
                KM8 = "4";
                KG8 = "Ş6";
            }
            if (lbl_m8.Text == "9")
            {
                KM8 = "S";
                KG8 = "ŞĞÖ";
            }
            if (lbl_m8.Text == "0")
            {
                KM8 = "0";
                KG8 = "Z";
            }
            if (lbl_m8.Text == "X" | lbl_m8.Text == "x")
            {
                KM8 = "W";
                KG8 = "HL";
            }
            if (lbl_m8.Text == "W" | lbl_m8.Text == "w")
            {
                KM8 = "X";
                KG8 = "ÖHL";
            }


            //K9
            if (lbl_m9.Text == "A" | lbl_m9.Text == "a")
            {
                KM9 = "L";
                KG9 = "DNÜ";
            }
            if (lbl_m9.Text == "B" | lbl_m9.Text == "b")
            {
                KM9 = "T";
                KG9 = "LFN";
            }
            if (lbl_m9.Text == "C" | lbl_m9.Text == "c")
            {
                KM9 = "Ş";
                KG9 = "KGO";
            }
            if (lbl_m9.Text == "Ç" | lbl_m9.Text == "ç")
            {
                KM9 = "B";
                KG9 = "1Y";
            }
            if (lbl_m9.Text == "D" | lbl_m9.Text == "d")
            {
                KM9 = "E";
                KG9 = "4U";
            }
            if (lbl_m9.Text == "E" | lbl_m9.Text == "e")
            {
                KM9 = "6";
                KG9 = "U4E";
            }
            if (lbl_m9.Text == "F" | lbl_m9.Text == "f")
            {
                KM9 = "9";
                KG9 = "Y1B";
            }
            if (lbl_m9.Text == "G" | lbl_m9.Text == "g")
            {
                KM9 = "J";
                KG9 = "BÖY";
            }
            if (lbl_m9.Text == "Ğ" | lbl_m9.Text == "ğ")
            {
                KM9 = "Ç";
                KG9 = "2V7";
            }
            if (lbl_m9.Text == "H" | lbl_m9.Text == "h")
            {
                KM9 = "Ö";
                KG9 = "ĞJS";
            }
            if (lbl_m9.Text == "I" | lbl_m9.Text == "ı")
            {
                KM9 = "K";
                KG9 = "ÇO";
            }
            if (lbl_m9.Text == "İ" | lbl_m9.Text == "i")
            {
                KM9 = "2";
                KG9 = "R8";
            }
            if (lbl_m9.Text == "J" | lbl_m9.Text == "j")
            {
                KM9 = "3";
                KG9 = "S7Ğ";
            }
            if (lbl_m9.Text == "K" | lbl_m9.Text == "k")
            {
                KM9 = "İ";
                KG9 = "APZ";
            }
            if (lbl_m9.Text == "L" | lbl_m9.Text == "l")
            {
                KM9 = "C";
                KG9 = "GUY";
            }
            if (lbl_m9.Text == "M" | lbl_m9.Text == "m")
            {
                KM9 = "N";
                KG9 = "FL";
            }
            if (lbl_m9.Text == "N" | lbl_m9.Text == "n")
            {
                KM9 = "I";
                KG9 = "9Q0";
            }
            if (lbl_m9.Text == "O" | lbl_m9.Text == "o")
            {
                KM9 = "M";
                KG9 = "EMU";
            }
            if (lbl_m9.Text == "Ö" | lbl_m9.Text == "ö")
            {
                KM9 = "V";
                KG9 = "OÇK";
            }
            if (lbl_m9.Text == "P" | lbl_m9.Text == "p")
            {
                KM9 = "Y";
                KG9 = "ÖBJ";
            }
            if (lbl_m9.Text == "Q" | lbl_m9.Text == "q")
            {
                KM9 = "F";
                KG9 = "5T4";
            }
            if (lbl_m9.Text == "R" | lbl_m9.Text == "r")
            {
                KM9 = "7";
                KG9 = "Ü3";
            }
            if (lbl_m9.Text == "S" | lbl_m9.Text == "s")
            {
                KM9 = "H";
                KG9 = "8R1";
            }
            if (lbl_m9.Text == "Ş" | lbl_m9.Text == "ş")
            {
                KM9 = "A";
                KG9 = "0Z9";
            }
            if (lbl_m9.Text == "T" | lbl_m9.Text == "t")
            {
                KM9 = "Ü";
                KG9 = "NDL";
            }
            if (lbl_m9.Text == "U" | lbl_m9.Text == "u")
            {
                KM9 = "Z";
                KG9 = "PAİ";
            }
            if (lbl_m9.Text == "Ü" | lbl_m9.Text == "ü")
            {
                KM9 = "D";
                KG9 = "3Ü6";
            }
            if (lbl_m9.Text == "V" | lbl_m9.Text == "v")
            {
                KM9 = "Ğ";
                KG9 = "7S2";
            }
            if (lbl_m9.Text == "Y" | lbl_m9.Text == "y")
            {
                KM9 = "O";
                KG9 = "GKŞ";
            }
            if (lbl_m9.Text == "Z" | lbl_m9.Text == "z")
            {
                KM9 = "8";
                KG9 = "V2Ç";
            }
            if (lbl_m9.Text == "1")
            {
                KM9 = "P";
                KG9 = "HİR";
            }
            if (lbl_m9.Text == "2")
            {
                KM9 = "U";
                KG9 = "MEM";
            }
            if (lbl_m9.Text == "3")
            {
                KM9 = "G";
                KG9 = "6Ş3";
            }
            if (lbl_m9.Text == "4")
            {
                KM9 = "Q";
                KG9 = "I";
            }
            if (lbl_m9.Text == "5")
            {
                KM9 = "5";
                KG9 = "T";
            }
            if (lbl_m9.Text == "6")
            {
                KM9 = "R";
                KG9 = "İHP";
            }
            if (lbl_m9.Text == "7")
            {
                KM9 = "1";
                KG9 = "Q9I";
            }
            if (lbl_m9.Text == "8")
            {
                KM9 = "4";
                KG9 = "Ş6";
            }
            if (lbl_m9.Text == "9")
            {
                KM9 = "S";
                KG9 = "ŞĞÖ";
            }
            if (lbl_m9.Text == "0")
            {
                KM9 = "0";
                KG9 = "Z";
            }
            if (lbl_m9.Text == "X" | lbl_m9.Text == "x")
            {
                KM9 = "W";
                KG9 = "HL";
            }
            if (lbl_m9.Text == "W" | lbl_m9.Text == "w")
            {
                KM9 = "X";
                KG9 = "ÖHL";
            }


            //K10
            if (lbl_m10.Text == "A" | lbl_m10.Text == "a")
            {
                KM10 = "L";
                KG10 = "DNÜ";
            }
            if (lbl_m10.Text == "B" | lbl_m10.Text == "b")
            {
                KM10 = "T";
                KG10 = "LFN";
            }
            if (lbl_m10.Text == "C" | lbl_m10.Text == "c")
            {
                KM10 = "Ş";
                KG10 = "KGO";
            }
            if (lbl_m10.Text == "Ç" | lbl_m10.Text == "ç")
            {
                KM10 = "B";
                KG10 = "1Y";
            }
            if (lbl_m10.Text == "D" | lbl_m10.Text == "d")
            {
                KM10 = "E";
                KG10 = "4U";
            }
            if (lbl_m10.Text == "E" | lbl_m10.Text == "e")
            {
                KM10 = "6";
                KG10 = "U4E";
            }
            if (lbl_m10.Text == "F" | lbl_m10.Text == "f")
            {
                KM10 = "9";
                KG10 = "Y1B";
            }
            if (lbl_m10.Text == "G" | lbl_m10.Text == "g")
            {
                KM10 = "J";
                KG10 = "BÖY";
            }
            if (lbl_m10.Text == "Ğ" | lbl_m10.Text == "ğ")
            {
                KM10 = "Ç";
                KG10 = "2V7";
            }
            if (lbl_m10.Text == "H" | lbl_m10.Text == "h")
            {
                KM10 = "Ö";
                KG10 = "ĞJS";
            }
            if (lbl_m10.Text == "I" | lbl_m10.Text == "ı")
            {
                KM10 = "K";
                KG10 = "ÇO";
            }
            if (lbl_m10.Text == "İ" | lbl_m10.Text == "i")
            {
                KM10 = "2";
                KG10 = "R8";
            }
            if (lbl_m10.Text == "J" | lbl_m10.Text == "j")
            {
                KM10 = "3";
                KG10 = "S7Ğ";
            }
            if (lbl_m10.Text == "K" | lbl_m10.Text == "k")
            {
                KM10 = "İ";
                KG10 = "APZ";
            }
            if (lbl_m10.Text == "L" | lbl_m10.Text == "l")
            {
                KM10 = "C";
                KG10 = "GUY";
            }
            if (lbl_m10.Text == "M" | lbl_m10.Text == "m")
            {
                KM10 = "N";
                KG10 = "FL";
            }
            if (lbl_m10.Text == "N" | lbl_m10.Text == "n")
            {
                KM10 = "I";
                KG10 = "9Q0";
            }
            if (lbl_m10.Text == "O" | lbl_m10.Text == "o")
            {
                KM10 = "M";
                KG10 = "EMU";
            }
            if (lbl_m10.Text == "Ö" | lbl_m10.Text == "ö")
            {
                KM10 = "V";
                KG10 = "OÇK";
            }
            if (lbl_m10.Text == "P" | lbl_m10.Text == "p")
            {
                KM10 = "Y";
                KG10 = "ÖBJ";
            }
            if (lbl_m10.Text == "Q" | lbl_m10.Text == "q")
            {
                KM10 = "F";
                KG10 = "5T4";
            }
            if (lbl_m10.Text == "R" | lbl_m10.Text == "r")
            {
                KM10 = "7";
                KG10 = "Ü3";
            }
            if (lbl_m10.Text == "S" | lbl_m10.Text == "s")
            {
                KM10 = "H";
                KG10 = "8R1";
            }
            if (lbl_m10.Text == "Ş" | lbl_m10.Text == "ş")
            {
                KM10 = "A";
                KG10 = "0Z9";
            }
            if (lbl_m10.Text == "T" | lbl_m10.Text == "t")
            {
                KM10 = "Ü";
                KG10 = "NDL";
            }
            if (lbl_m10.Text == "U" | lbl_m10.Text == "u")
            {
                KM10 = "Z";
                KG10 = "PAİ";
            }
            if (lbl_m10.Text == "Ü" | lbl_m10.Text == "ü")
            {
                KM10 = "D";
                KG10 = "3Ü6";
            }
            if (lbl_m10.Text == "V" | lbl_m10.Text == "v")
            {
                KM10 = "Ğ";
                KG10 = "7S2";
            }
            if (lbl_m10.Text == "Y" | lbl_m10.Text == "y")
            {
                KM10 = "O";
                KG10 = "GKŞ";
            }
            if (lbl_m10.Text == "Z" | lbl_m10.Text == "z")
            {
                KM10 = "8";
                KG10 = "V2Ç";
            }
            if (lbl_m10.Text == "1")
            {
                KM10 = "P";
                KG10 = "HİR";
            }
            if (lbl_m10.Text == "2")
            {
                KM10 = "U";
                KG10 = "MEM";
            }
            if (lbl_m10.Text == "3")
            {
                KM10 = "G";
                KG10 = "6Ş3";
            }
            if (lbl_m10.Text == "4")
            {
                KM10 = "Q";
                KG10 = "I";
            }
            if (lbl_m10.Text == "5")
            {
                KM10 = "5";
                KG10 = "T";
            }
            if (lbl_m10.Text == "6")
            {
                KM10 = "R";
                KG10 = "İHP";
            }
            if (lbl_m10.Text == "7")
            {
                KM10 = "1";
                KG10 = "Q9I";
            }
            if (lbl_m10.Text == "8")
            {
                KM10 = "4";
                KG10 = "Ş6";
            }
            if (lbl_m10.Text == "9")
            {
                KM10 = "S";
                KG10 = "ŞĞÖ";
            }
            if (lbl_m10.Text == "0")
            {
                KM10 = "0";
                KG10 = "Z";
            }
            if (lbl_m10.Text == "X" | lbl_m10.Text == "x")
            {
                KM10 = "W";
                KG10 = "HL";
            }
            if (lbl_m10.Text == "W" | lbl_m10.Text == "w")
            {
                KM10 = "X";
                KG10 = "ÖHL";
            }


            //K11
            if (lbl_m11.Text == "A" | lbl_m11.Text == "a")
            {
                KM11 = "L";
                KG11 = "DNÜ";
            }
            if (lbl_m11.Text == "B" | lbl_m11.Text == "b")
            {
                KM11 = "T";
                KG11 = "LFN";
            }
            if (lbl_m11.Text == "C" | lbl_m11.Text == "c")
            {
                KM11 = "Ş";
                KG11 = "KGO";
            }
            if (lbl_m11.Text == "Ç" | lbl_m11.Text == "ç")
            {
                KM11 = "B";
                KG11 = "1Y";
            }
            if (lbl_m11.Text == "D" | lbl_m11.Text == "d")
            {
                KM11 = "E";
                KG11 = "4U";
            }
            if (lbl_m11.Text == "E" | lbl_m11.Text == "e")
            {
                KM11 = "6";
                KG11 = "U4E";
            }
            if (lbl_m11.Text == "F" | lbl_m11.Text == "f")
            {
                KM11 = "9";
                KG11 = "Y1B";
            }
            if (lbl_m11.Text == "G" | lbl_m11.Text == "g")
            {
                KM11 = "J";
                KG11 = "BÖY";
            }
            if (lbl_m11.Text == "Ğ" | lbl_m11.Text == "ğ")
            {
                KM11 = "Ç";
                KG11 = "2V7";
            }
            if (lbl_m11.Text == "H" | lbl_m11.Text == "h")
            {
                KM11 = "Ö";
                KG11 = "ĞJS";
            }
            if (lbl_m11.Text == "I" | lbl_m11.Text == "ı")
            {
                KM11 = "K";
                KG11 = "ÇO";
            }
            if (lbl_m11.Text == "İ" | lbl_m11.Text == "i")
            {
                KM11 = "2";
                KG11 = "R8";
            }
            if (lbl_m11.Text == "J" | lbl_m11.Text == "j")
            {
                KM11 = "3";
                KG11 = "S7Ğ";
            }
            if (lbl_m11.Text == "K" | lbl_m11.Text == "k")
            {
                KM11 = "İ";
                KG11 = "APZ";
            }
            if (lbl_m11.Text == "L" | lbl_m11.Text == "l")
            {
                KM11 = "C";
                KG11 = "GUY";
            }
            if (lbl_m11.Text == "M" | lbl_m11.Text == "m")
            {
                KM11 = "N";
                KG11 = "FL";
            }
            if (lbl_m11.Text == "N" | lbl_m11.Text == "n")
            {
                KM11 = "I";
                KG11 = "9Q0";
            }
            if (lbl_m11.Text == "O" | lbl_m11.Text == "o")
            {
                KM11 = "M";
                KG11 = "EMU";
            }
            if (lbl_m11.Text == "Ö" | lbl_m11.Text == "ö")
            {
                KM11 = "V";
                KG11 = "OÇK";
            }
            if (lbl_m11.Text == "P" | lbl_m11.Text == "p")
            {
                KM11 = "Y";
                KG11 = "ÖBJ";
            }
            if (lbl_m11.Text == "Q" | lbl_m11.Text == "q")
            {
                KM11 = "F";
                KG11 = "5T4";
            }
            if (lbl_m11.Text == "R" | lbl_m11.Text == "r")
            {
                KM11 = "7";
                KG11 = "Ü3";
            }
            if (lbl_m11.Text == "S" | lbl_m11.Text == "s")
            {
                KM11 = "H";
                KG11 = "8R1";
            }
            if (lbl_m11.Text == "Ş" | lbl_m11.Text == "ş")
            {
                KM11 = "A";
                KG11 = "0Z9";
            }
            if (lbl_m11.Text == "T" | lbl_m11.Text == "t")
            {
                KM11 = "Ü";
                KG11 = "NDL";
            }
            if (lbl_m11.Text == "U" | lbl_m11.Text == "u")
            {
                KM11 = "Z";
                KG11 = "PAİ";
            }
            if (lbl_m11.Text == "Ü" | lbl_m11.Text == "ü")
            {
                KM11 = "D";
                KG11 = "3Ü6";
            }
            if (lbl_m11.Text == "V" | lbl_m11.Text == "v")
            {
                KM11 = "Ğ";
                KG11 = "7S2";
            }
            if (lbl_m11.Text == "Y" | lbl_m11.Text == "y")
            {
                KM11 = "O";
                KG11 = "GKŞ";
            }
            if (lbl_m11.Text == "Z" | lbl_m11.Text == "z")
            {
                KM11 = "8";
                KG11 = "V2Ç";
            }
            if (lbl_m11.Text == "1")
            {
                KM11 = "P";
                KG11 = "HİR";
            }
            if (lbl_m11.Text == "2")
            {
                KM11 = "U";
                KG11 = "MEM";
            }
            if (lbl_m11.Text == "3")
            {
                KM11 = "G";
                KG11 = "6Ş3";
            }
            if (lbl_m11.Text == "4")
            {
                KM11 = "Q";
                KG11 = "I";
            }
            if (lbl_m11.Text == "5")
            {
                KM11 = "5";
                KG11 = "T";
            }
            if (lbl_m11.Text == "6")
            {
                KM11 = "R";
                KG11 = "İHP";
            }
            if (lbl_m11.Text == "7")
            {
                KM11 = "1";
                KG11 = "Q9I";
            }
            if (lbl_m11.Text == "8")
            {
                KM11 = "4";
                KG11 = "Ş6";
            }
            if (lbl_m11.Text == "9")
            {
                KM11 = "S";
                KG11 = "ŞĞÖ";
            }
            if (lbl_m11.Text == "0")
            {
                KM11 = "0";
                KG11 = "Z";
            }
            if (lbl_m11.Text == "X" | lbl_m11.Text == "x")
            {
                KM11 = "W";
                KG11 = "HL";
            }
            if (lbl_m11.Text == "W" | lbl_m11.Text == "w")
            {
                KM11 = "X";
                KG11 = "ÖHL";
            }


            //K12
            if (lbl_m12.Text == "A" | lbl_m12.Text == "a")
            {
                KM12 = "L";
                KG12 = "DNÜ";
            }
            if (lbl_m12.Text == "B" | lbl_m12.Text == "b")
            {
                KM12 = "T";
                KG12 = "LFN";
            }
            if (lbl_m12.Text == "C" | lbl_m12.Text == "c")
            {
                KM12 = "Ş";
                KG12 = "KGO";
            }
            if (lbl_m12.Text == "Ç" | lbl_m12.Text == "ç")
            {
                KM12 = "B";
                KG12 = "1Y";
            }
            if (lbl_m12.Text == "D" | lbl_m12.Text == "d")
            {
                KM12 = "E";
                KG12 = "4U";
            }
            if (lbl_m12.Text == "E" | lbl_m12.Text == "e")
            {
                KM12 = "6";
                KG12 = "U4E";
            }
            if (lbl_m12.Text == "F" | lbl_m12.Text == "f")
            {
                KM12 = "9";
                KG12 = "Y1B";
            }
            if (lbl_m12.Text == "G" | lbl_m12.Text == "g")
            {
                KM12 = "J";
                KG12 = "BÖY";
            }
            if (lbl_m12.Text == "Ğ" | lbl_m12.Text == "ğ")
            {
                KM12 = "Ç";
                KG12 = "2V7";
            }
            if (lbl_m12.Text == "H" | lbl_m12.Text == "h")
            {
                KM12 = "Ö";
                KG12 = "ĞJS";
            }
            if (lbl_m12.Text == "I" | lbl_m12.Text == "ı")
            {
                KM12 = "K";
                KG12 = "ÇO";
            }
            if (lbl_m12.Text == "İ" | lbl_m12.Text == "i")
            {
                KM12 = "2";
                KG12 = "R8";
            }
            if (lbl_m12.Text == "J" | lbl_m12.Text == "j")
            {
                KM12 = "3";
                KG12 = "S7Ğ";
            }
            if (lbl_m12.Text == "K" | lbl_m12.Text == "k")
            {
                KM12 = "İ";
                KG12 = "APZ";
            }
            if (lbl_m12.Text == "L" | lbl_m12.Text == "l")
            {
                KM12 = "C";
                KG12 = "GUY";
            }
            if (lbl_m12.Text == "M" | lbl_m12.Text == "m")
            {
                KM12 = "N";
                KG12 = "FL";
            }
            if (lbl_m12.Text == "N" | lbl_m12.Text == "n")
            {
                KM12 = "I";
                KG12 = "9Q0";
            }
            if (lbl_m12.Text == "O" | lbl_m12.Text == "o")
            {
                KM12 = "M";
                KG12 = "EMU";
            }
            if (lbl_m12.Text == "Ö" | lbl_m12.Text == "ö")
            {
                KM12 = "V";
                KG12 = "OÇK";
            }
            if (lbl_m12.Text == "P" | lbl_m12.Text == "p")
            {
                KM12 = "Y";
                KG12 = "ÖBJ";
            }
            if (lbl_m12.Text == "Q" | lbl_m12.Text == "q")
            {
                KM12 = "F";
                KG12 = "5T4";
            }
            if (lbl_m12.Text == "R" | lbl_m12.Text == "r")
            {
                KM12 = "7";
                KG12 = "Ü3";
            }
            if (lbl_m12.Text == "S" | lbl_m12.Text == "s")
            {
                KM12 = "H";
                KG12 = "8R1";
            }
            if (lbl_m12.Text == "Ş" | lbl_m12.Text == "ş")
            {
                KM12 = "A";
                KG12 = "0Z9";
            }
            if (lbl_m12.Text == "T" | lbl_m12.Text == "t")
            {
                KM12 = "Ü";
                KG12 = "NDL";
            }
            if (lbl_m12.Text == "U" | lbl_m12.Text == "u")
            {
                KM12 = "Z";
                KG12 = "PAİ";
            }
            if (lbl_m12.Text == "Ü" | lbl_m12.Text == "ü")
            {
                KM12 = "D";
                KG12 = "3Ü6";
            }
            if (lbl_m12.Text == "V" | lbl_m12.Text == "v")
            {
                KM12 = "Ğ";
                KG12 = "7S2";
            }
            if (lbl_m12.Text == "Y" | lbl_m12.Text == "y")
            {
                KM12 = "O";
                KG12 = "GKŞ";
            }
            if (lbl_m12.Text == "Z" | lbl_m12.Text == "z")
            {
                KM12 = "8";
                KG12 = "V2Ç";
            }
            if (lbl_m12.Text == "1")
            {
                KM12 = "P";
                KG12 = "HİR";
            }
            if (lbl_m12.Text == "2")
            {
                KM12 = "U";
                KG12 = "MEM";
            }
            if (lbl_m12.Text == "3")
            {
                KM12 = "G";
                KG12 = "6Ş3";
            }
            if (lbl_m12.Text == "4")
            {
                KM12 = "Q";
                KG12 = "I";
            }
            if (lbl_m12.Text == "5")
            {
                KM12 = "5";
                KG12 = "T";
            }
            if (lbl_m12.Text == "6")
            {
                KM12 = "R";
                KG12 = "İHP";
            }
            if (lbl_m12.Text == "7")
            {
                KM12 = "1";
                KG12 = "Q9I";
            }
            if (lbl_m12.Text == "8")
            {
                KM12 = "4";
                KG12 = "Ş6";
            }
            if (lbl_m12.Text == "9")
            {
                KM12 = "S";
                KG12 = "ŞĞÖ";
            }
            if (lbl_m12.Text == "0")
            {
                KM12 = "0";
                KG12 = "Z";
            }
            if (lbl_m12.Text == "X" | lbl_m12.Text == "x")
            {
                KM12 = "W";
                KG12 = "HL";
            }
            if (lbl_m12.Text == "W" | lbl_m12.Text == "w")
            {
                KM12 = "X";
                KG12 = "ÖHL";
            }




            //////////////////////////////////////////////////////////////////////////////////////////////////

            string TS1 = "";
            string TS2 = "";
            string TD1 = "";
            string TD2 = "";
            string TSA1 = "";
            string TSA2 = "";
            string TA1 = "";
            string TA2 = "";
            string TY1 = "";
            string TY2 = "";
            string TG1 = "";
            string TG2 = "";

            string tarih_ay = Convert.ToString(blg.tarih().ToString("MM")).ToString();
            string tarih_yıl = Convert.ToString(blg.tarih().ToString("yy")).ToString();

            DateTime şimdi = DateTime.Now;

            string TS1_ = Convert.ToString(şimdi.ToString("ss").Substring(0,1));
            string TS2_ = Convert.ToString(şimdi.ToString("ss").Substring(1, 1));

            string TD1_ = Convert.ToString(şimdi.ToString("mm").Substring(0, 1));
            string TD2_ = Convert.ToString(şimdi.ToString("mm").Substring(1, 1));

            string TSA1_ = Convert.ToString(şimdi.ToString("hh").Substring(0, 1));
            string TSA2_ = Convert.ToString(şimdi.ToString("hh").Substring(1, 1));

            string TG1_ = Convert.ToString(şimdi.ToString("dd").Substring(0, 1));
            string TG2_ = Convert.ToString(şimdi.ToString("dd").Substring(1, 1));

            string TA1_ = tarih_ay.Substring(0,1);
            string TA2_ = tarih_ay.Substring(1, 1);

            string TY1_ = tarih_yıl.Substring(0,1);
            string TY2_ = tarih_yıl.Substring(1, 1);


            LTS1.Text = TS1_;
            LTS2.Text = TS2_;

            LTD1.Text = TD1_;
            LTD2.Text = TD2_;

            LTSA1.Text = TSA1_;
            LTSA2.Text = TSA2_;

            LTA1.Text = TA1_;
            LTA2.Text = TA2_;

            LTY1.Text = TY1_;
            LTY2.Text = TY2_;

            LTG1.Text = TG1_;
            LTG2.Text = TG2_;

            /////////////////////////////////////////////////////////////////////////////////////////////////////




            //TS1
            if (TS1_ == "0")
            {
                TS1 = "K";
            }
            if (TS1_ == "1")
            {
                TS1 = "B";
            }
            if (TS1_ == "2")
            {
                TS1 = "7";
            }
            if (TS1_ == "3")
            {
                TS1 = "V";
            }
            if (TS1_ == "4")
            {
                TS1 = "9";
            }
            if (TS1_ == "5")
            {
                TS1 = "T";
            }
            if (TS1_ == "6")
            {
                TS1 = "1";
            }
            if (TS1_ == "7")
            {
                TS1 = "2";
            }
            if (TS1_ == "8")
            {
                TS1 = "Ş";
            }
            if (TS1_ == "9")
            {
                TS1 = "4";
            }

            //TS2*
            if (TS2_ == "0")
            {
                TS2 = "FK";
            }
            if (TS2_ == "1")
            {
                TS2 = "MH";
            }
            if (TS2_ == "2")
            {
                TS2 = "FG";
            }
            if (TS2_ == "3")
            {
                TS2 = "CX";
            }
            if (TS2_ == "4")
            {
                TS2 = "5J";
            }
            if (TS2_ == "5")
            {
                TS2 = "38";
            }
            if (TS2_ == "6")
            {
                TS2 = "Ş9";
            }
            if (TS2_ == "7")
            {
                TS2 = "YG";
            }
            if (TS2_ == "8")
            {
                TS2 = "QP";
            }
            if (TS2_ == "9")
            {
                TS2 = "ÖE";
            }



            //TD1
            if (TD1_ == "0")
            {
                TD1 = "K";
            }
            if (TD1_ == "1")
            {
                TD1 = "B";
            }
            if (TD1_ == "2")
            {
                TD1 = "7";
            }
            if (TD1_ == "3")
            {
                TD1 = "V";
            }
            if (TD1_ == "4")
            {
                TD1 = "9";
            }
            if (TD1_ == "5")
            {
                TD1 = "T";
            }
            if (TD1_ == "6")
            {
                TD1 = "1";
            }
            if (TD1_ == "7")
            {
                TD1 = "2";
            }
            if (TD1_ == "8")
            {
                TD1 = "Ş";
            }
            if (TD1_ == "9")
            {
                TD1 = "4";
            }


            //TD2*
            if (TD2_ == "0")
            {
                TD2 = "GH";
            }
            if (TD2_ == "1")
            {
                TD2 = "UY";
            }
            if (TD2_ == "2")
            {
                TD2 = "67";
            }
            if (TD2_ == "3")
            {
                TD2 = "ŞL";
            }
            if (TD2_ == "4")
            {
                TD2 = "JN";
            }
            if (TD2_ == "5")
            {
                TD2 = "S6";
            }
            if (TD2_ == "6")
            {
                TD2 = "FE";
            }
            if (TD2_ == "7")
            {
                TD2 = "TY";
            }
            if (TD2_ == "8")
            {
                TD2 = "UK";
            }
            if (TD2_ == "9")
            {
                TD2 = "SW";
            }

            //TSA1
            if (TSA1_ == "0")
            {
                TSA1 = "K";
            }
            if (TSA1_ == "1")
            {
                TSA1 = "B";
            }
            if (TSA1_ == "2")
            {
                TSA1 = "7";
            }
            if (TSA1_ == "3")
            {
                TSA1 = "V";
            }
            if (TSA1_ == "4")
            {
                TSA1 = "9";
            }
            if (TSA1_ == "5")
            {
                TSA1 = "T";
            }
            if (TSA1_ == "6")
            {
                TSA1 = "1";
            }
            if (TSA1_ == "7")
            {
                TSA1 = "2";
            }
            if (TSA1_ == "8")
            {
                TSA1 = "Ş";
            }
            if (TSA1_ == "9")
            {
                TSA1 = "4";
            }

            //TSA2
            if (TSA2_ == "0")
            {
                TSA2 = "K";
            }
            if (TSA2_ == "1")
            {
                TSA2 = "B";
            }
            if (TSA2_ == "2")
            {
                TSA2 = "7";
            }
            if (TSA2_ == "3")
            {
                TSA2 = "V";
            }
            if (TSA2_ == "4")
            {
                TSA2 = "9";
            }
            if (TSA2_ == "5")
            {
                TSA2 = "T";
            }
            if (TSA2_ == "6")
            {
                TSA2 = "1";
            }
            if (TSA2_ == "7")
            {
                TSA2 = "2";
            }
            if (TSA2_ == "8")
            {
                TSA2 = "Ş";
            }
            if (TSA2_ == "9")
            {
                TSA2 = "4";
            }


            //TA1
            if (TA1_ == "0")
            {
                TA1 = "K";
            }
            if (TA1_ == "1")
            {
                TA1 = "B";
            }
            if (TA1_ == "2")
            {
                TA1 = "7";
            }
            if (TA1_ == "3")
            {
                TA1 = "V";
            }
            if (TA1_ == "4")
            {
                TA1 = "9";
            }
            if (TA1_ == "5")
            {
                TA1 = "T";
            }
            if (TA1_ == "6")
            {
                TA1 = "1";
            }
            if (TA1_ == "7")
            {
                TA1 = "2";
            }
            if (TA1_ == "8")
            {
                TA1 = "Ş";
            }
            if (TA1_ == "9")
            {
                TA1 = "4";
            }


            //TA2
            if (TA2_ == "0")
            {
                TA2 = "K";
            }
            if (TA2_ == "1")
            {
                TA2 = "B";
            }
            if (TA2_ == "2")
            {
                TA2 = "7";
            }
            if (TA2_ == "3")
            {
                TA2 = "V";
            }
            if (TA2_ == "4")
            {
                TA2 = "9";
            }
            if (TA2_ == "5")
            {
                TA2 = "T";
            }
            if (TA2_ == "6")
            {
                TA2 = "1";
            }
            if (TA2_ == "7")
            {
                TA2 = "2";
            }
            if (TA2_ == "8")
            {
                TA2 = "Ş";
            }
            if (TA2_ == "9")
            {
                TA2 = "4";
            }


            //TY1
            if (TY1_ == "0")
            {
                TY1 = "K";
            }
            if (TY1_ == "1")
            {
                TY1 = "B";
            }
            if (TY1_ == "2")
            {
                TY1 = "7";
            }
            if (TY1_ == "3")
            {
                TY1 = "V";
            }
            if (TY1_ == "4")
            {
                TY1 = "9";
            }
            if (TY1_ == "5")
            {
                TY1 = "T";
            }
            if (TY1_ == "6")
            {
                TY1 = "1";
            }
            if (TY1_ == "7")
            {
                TY1 = "2";
            }
            if (TY1_ == "8")
            {
                TY1 = "Ş";
            }
            if (TY1_ == "9")
            {
                TY1 = "4";
            }


            //TY2
            if (TY2_ == "0")
            {
                TY2 = "K";
            }
            if (TY2_ == "1")
            {
                TY2 = "B";
            }
            if (TY2_ == "2")
            {
                TY2 = "7";
            }
            if (TY2_ == "3")
            {
                TY2 = "V";
            }
            if (TY2_ == "4")
            {
                TY2 = "9";
            }
            if (TY2_ == "5")
            {
                TY2 = "T";
            }
            if (TY2_ == "6")
            {
                TY2 = "1";
            }
            if (TY2_ == "7")
            {
                TY2 = "2";
            }
            if (TY2_ == "8")
            {
                TY2 = "Ş";
            }
            if (TY2_ == "9")
            {
                TY2 = "4";
            }


            //TG1
            if (TG1_ == "0")
            {
                TG1 = "K";
            }
            if (TG1_ == "1")
            {
                TG1 = "B";
            }
            if (TG1_ == "2")
            {
                TG1 = "7";
            }
            if (TG1_ == "3")
            {
                TG1 = "V";
            }
            if (TG1_ == "4")
            {
                TG1 = "9";
            }
            if (TG1_ == "5")
            {
                TG1 = "T";
            }
            if (TG1_ == "6")
            {
                TG1 = "1";
            }
            if (TG1_ == "7")
            {
                TG1 = "2";
            }
            if (TG1_ == "8")
            {
                TG1 = "Ş";
            }
            if (TG1_ == "9")
            {
                TG1 = "4";
            }


            //TG2
            if (TG2_ == "0")
            {
                TG2 = "K";
            }
            if (TG2_ == "1")
            {
                TG2 = "B";
            }
            if (TG2_ == "2")
            {
                TG2 = "7";
            }
            if (TG2_ == "3")
            {
                TG2 = "V";
            }
            if (TG2_ == "4")
            {
                TG2 = "9";
            }
            if (TG2_ == "5")
            {
                TG2 = "T";
            }
            if (TG2_ == "6")
            {
                TG2 = "1";
            }
            if (TG2_ == "7")
            {
                TG2 = "2";
            }
            if (TG2_ == "8")
            {
                TG2 = "Ş";
            }
            if (TG2_ == "9")
            {
                TG2 = "4";
            }

            lbl_g1.Text = KG1;
            lbl_g2.Text = KG2;
            lbl_g3.Text = KG3;
            lbl_g4.Text = KG4;
            lbl_g5.Text = KG5;
            lbl_g6.Text = KG6;
            lbl_g7.Text = KG7;
            lbl_g8.Text = KG8;
            lbl_g9.Text = KG9;
            lbl_g10.Text = KG10;
            lbl_g11.Text = KG11;
            lbl_g12.Text = KG12;

            LBL_TS1.Text = TS1;
            LBL_TS2.Text = TS2;
            LBL_TD1.Text = TD1;
            LBL_TD2.Text = TD2;
            LBL_TA1.Text = TA1;
            LBL_TA2.Text = TA2;
            LBL_TY1.Text = TY1;
            LBL_TY2.Text = TY2;
            LBL_TSA1.Text = TSA1;
            LBL_TSA2.Text = TSA2;
            LBL_TG1.Text = TG1;
            LBL_TG2.Text = TG2;

            string v1 = TS2;
            string v2 = TG2;
            string v3 = TS1;
            string v4 = KM10;
            string v5 = KM3;
            string v6 = KM6;
            string v7 = TSA2;
            string v8 = KM7;
            string v9 = TSA1;
            string v10 = KM11;
            string v11 = TA2;
            string v12 = KM9;
            string v13 = TA1;
            string v14 = KM2;
            string v15 = TY2;
            string v16 = KM4;
            string v17 = TY1;
            string v18 = KM1;
            string v19 = KM8;
            string v20 = TG1;
            string v21 = KM12;
            string v22 = KM5;
            string v23 = TD1;
            string v24 = TD2;


            string d1 = TS2;
            string d2 = TG2;
            string d3 = TS1;
            string d4 = KG10;
            string d5 = KG3;
            string d6 = KG6;
            string d7 = TSA2;
            string d8 = KG7;
            string d9 = TSA1;
            string d10 = KG11;
            string d11 = TA2;
            string d12 = KG9;
            string d13 = TA1;
            string d14 = KG2;
            string d15 = TY2;
            string d16 = KG4;
            string d17 = TY1;
            string d18 = KG1;
            string d19 = KG8;
            string d20 = TG1;
            string d21 = KG12;
            string d22 = KG5;
            string d23 = TD1;
            string d24 = TD2;


            string s1 = "";
            string s2 = "";
            string s3 = "";
            string s4 = "";
            string s5 = "";

            string sd1 = "L";
            string sd2 = "O";
            string sd3 = "Y";
            string sd4 = "A";
            string sd5 = "Z";
            string sd6 = "1";

            txt_verilenkod.Text = ""+ v1 + ""+s1+""+ v2 + ""+ v3 + ""+ v4 + ""+ s2 +""+ v5 + ""+s3+""+ v6 + ""+ v7 + ""+ v8 + ""+ v9 + ""+ v10 + ""+ v11 + ""+ v12 +""+ v13 + ""+s4+""+ v14 + ""+ v15 + ""+ v16 + ""+ v17 + ""+ v18 + ""+s5+""+ v19 + ""+ v20 + ""+ v21 + ""+ v22 +""+v23+""+v24+"";
            lbl_doğrula1.Text = ""+ TD1 +""+ TSA1 +"" + d1 + ""+ sd1 +"" + d2 + "" + d3 + "" + d4 + ""+ sd2 +"" + d5 + ""+sd3+"" + d6 + "" + d7 + "" + d8 + "" + d9 + "" + d10 + "" + d11 + "" + d12 + "" + d13 + ""+sd4+"" + d14 + "" + d15 + "" + d16 + "" + d17 + "" + d18 + ""+ sd5 +"" + d19 + "" + d20 + "" + d21 + "" + d22 + "" + d23 + ""+sd6+"" + d24 + "" + TS1+""+ TSA2 +"";
        }

        public string MACAdresiAl()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty) sMacAddress = adapter.GetPhysicalAddress().ToString();
            }
            return sMacAddress;
        }

        private void Devexpress_Load(object sender, EventArgs e)
        {
            çözüm();
            groupControl_kontrol.Visible = blg.visabledurumu();
        }

        private void btn_kontrolet_Click(object sender, EventArgs e)
        {
            if (txt_alınankod.Text == lbl_doğrula1.Text)
            {
                MessageBox.Show("Lisanslama işlemi başarıyla tamamlandı. Lütfen LOYAZ'ı yeniden başlatın");
                yaz();
                yaz2();
            }
        }
        private void yaz()
        {
            string TG1 = LBL_TG1.Text;
            string TG2 = LBL_TG2.Text;
            string TA1 = LBL_TA1.Text;
            string TA2 = LBL_TA2.Text;
            string TY1 = LBL_TY1.Text;
            string TY2 = LBL_TY2.Text;

            string TSA1 = LBL_TSA1.Text;
            string TSA2 = LBL_TSA2.Text;
            string TD1 = LBL_TD1.Text;
            string TD2 = LBL_TD2.Text;
            string TS1 = LBL_TS1.Text;
            string TS2 = LBL_TS2.Text;


            string dosya_yolu = "" + Application.StartupPath + @"\es\\DevExpress.XtraVerticalGrid.v20.1.resources_adn.dll";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("vkd:"+txt_verilenkod.Text+"");
            sw.WriteLine("akd:" + txt_alınankod.Text + "");
            sw.WriteLine("trh:" + TG1 + ""+TG2+"/"+TA1+""+TA2+"/"+TY1+""+TY2+"");
            sw.WriteLine("st:" + TSA1 + "" + TSA2 + ":" + TD1 + "" + TD2 + ":" + TS1 + "" + TS2 + "");
            sw.WriteLine("hst:" + Dns.GetHostName() + "");
            sw.WriteLine("mc:" + MACAdresiAl() + "");
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        private void yaz2()
        {
            string dosya_yolu = "" + Application.StartupPath + @"\ja\\DevExpress.XtraVerticalGrid.v20.1.resourcesr_adn.dll";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("" + MACAdresiAl() + "");
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}