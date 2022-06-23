using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp
{

    public enum Operators { Add, Sub, Multi, Div }


    public partial class Calculator : Form
    {
        public double result = 0;
        public bool isNew = true;
        public Operators optSet = Operators.Add;

        public Calculator()
        {
            InitializeComponent();
        }


        //숫자버튼 클릭
        private void Number_Click(object sender, EventArgs e)
        {
            //버튼의 숫자 확인
            Button btnNum = (Button)sender;
            string num = btnNum.Text.ToString();

            //처음 수인지 이어지는 수인지 확인
            if (NumScreen.Text == "0" || isNew == true)
            {
                NumScreen.Text = num;
                isNew = false;
            }
            else
            {
                NumScreen.Text += num;
            }
        }
        
        //연산자 버튼 클릭

        private void OptButton_Click(object sender, EventArgs e)
        {
            
            //버튼의 연산 기호확인
            Button btnOpt = (Button)sender;
            string opt = btnOpt.Text.ToString();

            //새로운 숫자 입력 후 연산버튼을 눌렀을 때만 연산
            if (isNew == false) 
            {
                Calculate();
                SetScreen();

                //연산 후 입력상태 초기화
                isNew = true;
            }

            //현재 눌려진 연산기호 저장
            if (string.Equals(opt, "+")) {      optSet = Operators.Add; }
            else if (string.Equals(opt, "-")) { optSet = Operators.Sub; }
            else if (string.Equals(opt, "×")) { optSet = Operators.Multi; }
            else if (string.Equals(opt, "÷")) { optSet = Operators.Div; }
            
        }

        //이퀄버튼 클릭
        private void EqualButton_Click(object sender, EventArgs e)
        {
            //이전에 숫자가 잆력된 상태일때만 계산
            if (isNew == false) 
            {
                Calculate();
            }

            //결괏값 표시
            SetScreen();
            isNew = true;
        }

        //클리어 버튼 클릭
        private void ClearButton_Click(object sender, EventArgs e)
        {
            result = 0;
            isNew = true;
            optSet = Operators.Add;
            NumScreen.Text = "0";
        }


        //최종값 화면 출력 기능
        private void SetScreen() {

            if (result % 1 == 0)
            {
                NumScreen.Text = result.ToString("N0");
            }
            else
            {
                NumScreen.Text = result.ToString("N");
            }
        }

        //계산기능
        private void Calculate() { 
            
                //현재 입력창의 수 저장
                double num = Double.Parse(NumScreen.Text);

                //저장된 연산기호와 값으로 현재값과 연산
                if (optSet == Operators.Add) result += num;
                else if (optSet == Operators.Sub) result -= num;
                else if (optSet == Operators.Multi) result *= num;
                else if (optSet == Operators.Div) result /= num;
        }

    }//Calculatoer
}
