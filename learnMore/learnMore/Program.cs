using System;
using System.Collections.Generic;

public delegate void SuKienNhapSo (int x);

class DuLieuNhap : EventArgs {
    public int data {set; get;}
    public DuLieuNhap (int x) => data = x;
}

class UserInput{

    // public SuKienNhapSo suKienNhapSo { set; get;}
    //public event SuKienNhapSo suKienNhapSo; //! event - ko thuc hien phep gan

    //~delegate void KIEU(object? sender, EventArgs e)
    public event EventHandler suKienNhapSo; 

    public void Input(){
        do{
            Console.Write("Nhap so: ");
            string s = Console.ReadLine();
            int i = Int32.Parse(s);
            // suKienNhapSo?.Invoke(i);
            suKienNhapSo?.Invoke(this, new DuLieuNhap(i));
        }
        while(true);
    }
}

class TinhCan{

    public void Sub(UserInput input){
        input.suKienNhapSo += Can;  //! += not =
    }

    public void Can(object sender, EventArgs e){
        DuLieuNhap duLieuNhap = (DuLieuNhap)e;
        int i = duLieuNhap.data;
        Console.WriteLine($"Can: {Math.Sqrt(i)}");
    }

    // public void Can (int i){
    //     Console.WriteLine($"Can: {Math.Sqrt(i)}");
    // }
}

class Program
{
    static void Main(string[] args){

        Console.CancelKeyPress += (sender, e) => {
            Console.WriteLine();
            Console.WriteLine("Exiting");
        };

        UserInput userInput = new UserInput();

        // userInput.suKienNhapSo += x =>{
        //     Console.WriteLine("Ban vua nhap so: " + x);
        // };
        userInput.suKienNhapSo += (sender, e) =>{
            DuLieuNhap dulieunhap = (DuLieuNhap)e;
            Console.WriteLine("Ban vua nhap so: " + dulieunhap.data);
        };

        TinhCan so = new TinhCan ();
        so.Sub(userInput);

        userInput.Input();
    }
}
