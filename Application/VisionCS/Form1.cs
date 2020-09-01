using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace VisionCS
{
    public partial class Form1 : Form
    {
        int m_hDLL;
        IntPtr intPtr;
        Bitmap m_bmp;



        [DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
        private extern static int LoadLibrary(string libraryname);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
        private extern static IntPtr GetProcAddress(int hwnd, string proname);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
        private extern static bool FreeLibrary(int hModule);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate int EngineInit();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate int EngineVisionCS
            (
                byte[] ret,
                byte[] gry, int w, int h
            );
        public Form1()
        {
            unsafe
            {
                m_hDLL = LoadLibrary("VisionDll.dll");
                if (m_hDLL == 0) MessageBox.Show("Error dll load!");
            }
            InitializeComponent();

            intPtr = GetProcAddress(m_hDLL, "EngineInit");
            EngineInit InitEngine = (EngineInit)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(EngineInit));
            int day = InitEngine();
            if (day == 0)
                MessageBox.Show("라이브러리 유효기한이 지났습니다!!");
            else
            {
                String srtMessage = String.Format("유효기한이 {0}일 남았습니다", day);
                MessageBox.Show(srtMessage);
            }
        }
        private void ButtonVision_Click(object sender, EventArgs e)
        {
            if (PictureBoxMain.Image == null) return;
            int w = m_bmp.Width;
            int h = m_bmp.Height;

            byte[] col = Get3BytePixelDataFromBitmap(m_bmp, w, h);

            byte[] ret = new byte[w * h * 3];
            intPtr = GetProcAddress(m_hDLL, "EngineHistogramEqualization");
            EngineVisionCS HistogramEqualization =
                (EngineVisionCS)Marshal.GetDelegateForFunctionPointer(intPtr,
                        typeof(EngineVisionCS));
            HistogramEqualization(ret, col, w, h);

            Display3BytePixelDataToPictureBox(ret, w, h, 24);
        }

        private byte[] Get3BytePixelDataFromBitmap(Bitmap bmp, int w, int h)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                            bmp.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;

            byte[] colValue = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, colValue, 0, bytes);

            bmp.UnlockBits(bmpData);
            byte[] col = new byte[w * h * 3];
            for (int i = 0; i < w * h; i++)
            {
                col[i * 3 + 0] = colValue[i * 4 + 0];
                col[i * 3 + 1] = colValue[i * 4 + 1];
                col[i * 3 + 2] = colValue[i * 4 + 2];
            }
            return col;
        }

        private void Display3BytePixelDataToPictureBox(byte[] col, int w, int h, int BitsPerPixel)
        {
            int x, y;
            byte[] raw = new byte[w * h * 4];

            for (y = 0; y < h; y++)
            {
                for (x = 0; x < w; x++)
                {
                    raw[(4 * w) * (y) + (4 * x) + 0] = col[(3 * w) * (y) + (3 * x) + 0];
                    raw[(4 * w) * (y) + (4 * x) + 1] = col[(3 * w) * (y) + (3 * x) + 1];
                    raw[(4 * w) * (y) + (4 * x) + 2] = col[(3 * w) * (y) + (3 * x) + 2];
                }
            }
            Bitmap graybmp = RawTo32BitsBitmap(raw, w, h);

            PictureBoxMain.Image = graybmp;
            PictureBoxMain.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxMain.Refresh();
        }

        private Bitmap RawTo32BitsBitmap(byte[] raw, int w, int h)
        {
            Bitmap res = new Bitmap(w, h, PixelFormat.Format32bppRgb);
            BitmapData data = res.LockBits(
                                                    new Rectangle(0, 0, w, h),
                                                    ImageLockMode.ReadOnly,
                                                    PixelFormat.Format32bppRgb);
            IntPtr ptr = data.Scan0;
            Marshal.Copy(raw, 0, ptr, w * h * 4);
            res.UnlockBits(data);
            return res;
        }



        private void ButtonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog MyOpenFileDialog = new OpenFileDialog();
            MyOpenFileDialog.ShowDialog();
            string filePath = MyOpenFileDialog.FileName;

            LoadBitmapDisplayViewScreen(filePath);
        }

        private void LoadBitmapDisplayViewScreen(string filePath)
        {
            Image image = Image.FromFile(filePath);

            PictureBoxMain.Image = image;
            PictureBoxMain.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxMain.Refresh();

            Label_message.Text = Path.GetFileName(filePath);

            m_bmp = new Bitmap(image);
            Label_message.Text = " w= " + m_bmp.Width + " h= " +
                m_bmp.Height;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            FreeLibrary(m_hDLL);
            this.Close();
        }
    }

}