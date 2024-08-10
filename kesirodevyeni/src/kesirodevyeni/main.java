package kesirodevyeni;

import java.util.Scanner;

public class main {

	public static void main(String[] args) {
		
		kesir kesir= new kesir();
		

		Scanner s = new Scanner(System.in);
		System.out.println("pay1 ve payda1 giriniz");
		int pay1 = s.nextInt();
		kesir.setPay1(pay1);
		int payda1 = s.nextInt();
		kesir.setPayda1(payda1);
		
		System.out.println("pay2 ve payda2 giriniz");
		int pay2 = s.nextInt();
		kesir.setPay2(pay2);
		int payda2 = s.nextInt();
		kesir.setPayda2(payda2);
		
		kesir.paytopla();
		kesir.paydatopla();
		
		
		
		
		

	}

}
