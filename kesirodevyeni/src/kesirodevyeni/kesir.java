package kesirodevyeni;



public class kesir {
	

private static int pay1,payda1,pay2,payda2;

public static int getPay1() {
	return pay1;
}
public static void setPay1(int pay1) {
	kesir.pay1 = pay1;
}
public static int getPayda1() {
	return payda1;
}
public static void setPayda1(int payda1) {
	kesir.payda1 = payda1;
}
public static int getPay2() {
	return pay2;
}
public static void setPay2(int pay2) {
	kesir.pay2 = pay2;
}
public static int getPayda2() {
	return payda2;
}
public static void setPayda2(int payda2) {
	kesir.payda2 = payda2;
}


   public static void paytopla()  
   {
	   if(payda1==0 || payda2==0 )
	   {
		   System.out.println("başarısız işlem kesir tanımsızdır");
		   return;
		   
	   }
	   else if(payda1==payda2)
	   {
		   int pay=pay1+pay2;
		   System.out.println("pay="+pay);
	   }
	   else if(payda1 != payda2)
	   {
		   int pay= ((pay1*payda2)+(pay2*payda1));
		   System.out.println("pay= "+pay);
	   }
   }
   public static  void paydatopla()
   {
	   if(payda1==0 || payda2==0)
	   {
		   System.out.println("başarısız işlem kesir tanımsızdır");
		   
	   }
	   else if(payda1 == payda2)
	   {
		   int payda=payda1;
		   System.out.println("payda= "+payda);
	   }
	   else if(payda1 != payda2)
	   {
		    int  payda=(payda1*payda2);
		    System.out.println("payda= "+payda);
	   }
   }
	   
   
   
}
