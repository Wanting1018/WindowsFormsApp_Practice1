using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        // 顯示黃色的 都是方法(Methods)

        // 從textbox上面獲取的值是字串   -> 因此要轉換
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 公分轉英吋_Click(object sender, EventArgs e)
        {
            if (txt公分.Text != "")  // 存放在txt公分.Text 判斷它是否不為空字串
            {
                try   // 當try區塊發生錯誤時，就會移向catch區塊，用Exception擷取錯誤
                      // 把可能產生的例外錯誤的程式碼包起來
                      // 只能有一個try  
                      // else那邊不太可能發生錯誤 所以不用包
                      // 有看到exception 錯誤 可以用try catch
                {
                    // 先取得使用者輸入的字串
                    string strInput = txt公分.Text;  // strInput自行定義的變數
                                                   // 字串不能拿來運算 所以要轉換成浮點
                    float myCM = 0.0f;
                    float myInch = 0.0f;
                    // 定義一個變數myCM為浮點數 字串轉換後才能放

                    myCM = Convert.ToSingle(strInput);  // 將轉換成的浮點數放在myCM
                    myInch = myCM * 0.3937f;

                    txt英吋.Text = Convert.ToString(myInch); // 不能指定浮點到字串區 所以要再將浮點轉換成字串
                    /* 可簡寫成 ：
                    txt英吋.Text = myInch.ToString();
                    */


                    // 設定值 = 取值
                }
                catch(Exception error)  // catch區塊 要跟try同一層級
                // 例外錯誤就會進來這個catch區塊裡面
                // try如果沒有產生錯誤 catch區塊就不會執行
                {
                    MessageBox.Show(error.Message);
                    txt英吋.Clear();
                }
            }
            else
            {
                MessageBox.Show("請輸入公分數值");
                txt英吋.Text = " ";
            }
        }

        // 以下開始自行完成

        private void 英吋轉公分_Click(object sender, EventArgs e)
        {
            if (txt英吋.Text != "") 
            {
                string strInput = txt英吋.Text;
                float myCM = 0.0f;
                float myInch = 0.0f;
                
                myInch = Convert.ToSingle(strInput);
                myCM = myInch * 2.54f;

                txt公分.Text=myCM.ToString();
                

            }
            else
            {
                MessageBox.Show("請輸入英吋數值");
                txt公分.Text = "";
            }
        }

        private void 坪數轉平方公尺_Click(object sender, EventArgs e)
        {
            if (txt坪數.Text != "") 
            {
                double my坪數, my平方公尺 = 0.0;  // 同類型的變數可以在同一行定義 用逗號隔開
                my坪數 = Convert.ToDouble(txt坪數.Text);
                my平方公尺 = my坪數 * 3.3058;
                
                //txt平方公尺.Text = $"{my平方公尺}";
                //txt平方公尺.Text = my平方公尺.ToString();
                //txt平方公尺.Text = Convert.ToString(my平方公尺);
                txt平方公尺.Text = String.Format("{0:F2}", my平方公尺);  // -> 最常用
                //txt平方公尺.Text = String.Format("{0.F2}", my平方公尺);
                //// console.writeline 寫的東西可以在string.format()使用
                //// string.format() -> 字串的格式化


            }
            else
            {
                MessageBox.Show("請輸入坪數數值");
                txt平方公尺.Clear();
            }

        }

        private void 平方公尺轉坪數_Click(object sender, EventArgs e)
        {
            if (txt平方公尺.Text != "")  
            {
                double my平方公尺, my坪數 = 0.0;
                my平方公尺 = Convert.ToDouble(txt平方公尺.Text);
                my坪數 = my平方公尺 * 0.3025;

                txt坪數.Text = String.Format("{0:F2}", my坪數);  // 0為固定 ; F2到小數點第2位
            }
            else
            {
                MessageBox.Show("請輸入平方公尺數值");
                txt坪數.Clear();
            }
        }


        // 處理例外錯誤(exception error) ex使用者輸入英文 中文 亂碼...等
        private void 公斤轉磅_Click(object sender, EventArgs e)
        {
            if (txt公斤.Text.Length > 0)  
            {
                double myKG, myPound = 0.0;
                bool is轉換成功 = false;

                is轉換成功 = Double.TryParse(txt公斤.Text, out myKG);  // 將字串轉換成double 儲存到myKG
                // 只是單純的資料轉換
                // 把第一個字串參數(txt公斤.Text)的資料轉換成double 塞進第二個參數(myKG) 成功的話會回傳true 
                // 轉換失敗 第二個參數就不動 並且回傳false  (轉換失敗就是當今天輸入者 輸入中文 英文亂碼之類的)
                // try catch 能處理所有的例外錯誤 (陣列操作 集合操作這些的錯誤)
                // tryparse 只能處理資料型態轉換的例外錯誤
                // out 可以視為ref 可以為空 ref不行為空


                if (is轉換成功 == true) 
                {
                    // 轉換成功
                    myPound = myKG * 2.2;
                    txt磅.Text = String.Format("{0:F2}", myPound);
                }
                else
                {
                    // 轉換失敗
                    MessageBox.Show("輸入公斤數值有錯誤");
                    txt磅.Clear();
                }
            }
            else
            {
                MessageBox.Show("請輸入公斤數值");
                txt磅.Clear();             
            }
        }

        private void 磅轉公斤_Click(object sender, EventArgs e)
        {
            if (txt磅.Text.Length > 0) 
            {
                double my磅, my公斤 = 0.0;
                bool is轉換成功 = false;

                is轉換成功 = Double.TryParse(txt磅.Text, out my磅);
                
                    
                if(is轉換成功 == true)
                {
                    my公斤 = my磅 * 0.453;
                    txt公斤.Text = String.Format("{0:F2}", my公斤);
                }
                else
                {
                    MessageBox.Show("輸入的磅數有錯誤");
                    txt公斤.Clear();
                }
            }
            else
            {
                MessageBox.Show("請輸入磅數");
                txt公斤.Clear();
            }
        }
    }
}
