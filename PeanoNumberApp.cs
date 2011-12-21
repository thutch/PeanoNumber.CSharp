

using System;

namespace PeanoNumberNamespace
{

	
	public class PeanoNumber
	{
		public PeanoNumber pred;
		
		public PeanoNumber()
		{
		}		
		
		public static PeanoNumber fromInteger(int num)
		{ 
//			System.Console.WriteLine("fromInteger({0})", num); 
			if(num == 0)
			{
//				System.Console.WriteLine("zero"); 
				return new Zero();
			}
			else
			{ 
//				System.Console.WriteLine("entering recursive call"); 
			 	PeanoNumber tPNum = PeanoNumber.fromInteger(num - 1);
				return  of(tPNum);
				}
		}
		
		public static PeanoNumber of(PeanoNumber aPeanoNumber)
		{ 
//			System.Console.WriteLine("executing of"); 
			PeanoNumber tPNum = new Succ();
			tPNum.setPred(aPeanoNumber);
			return tPNum;
		}
		
	public static PeanoNumber operator + (PeanoNumber a, PeanoNumber b)
	{
		return a.addPeanoNumber(b);
	}
		

	public virtual PeanoNumber addPeanoNumber(PeanoNumber aPeanoNumber)
	{
		PeanoNumber subTotal;
		subTotal = this.pred.addPeanoNumber(aPeanoNumber);
		return subTotal.succ();
	}
	


	public void setPred(PeanoNumber aPeanoNumber)
		
	{
		this.pred = aPeanoNumber;
	}

	
	public PeanoNumber succ()
	{
		return Succ.of(this);
	}
	
	
	public virtual void print()
	{
	}
	
		
	}



public class Succ : PeanoNumber {
		
	public Succ()
	{
	}
	
	public Succ(PeanoNumber aPeanoNumber)
	{
		pred = aPeanoNumber;
		
	}
	
	public override void print()
	{
		System.Console.Write("succ(");
		this.pred.print();
		System.Console.Write(")");
	}
	
}

public class Zero : PeanoNumber {
	
	public override PeanoNumber addPeanoNumber(PeanoNumber aPeanoNumber)
	{
		return aPeanoNumber;
	}
	
	public override void print()
	{
		System.Console.Write("zero");
	}
	
}


public class PeanoNumberApp {

	public static void Main()
	{
		PeanoNumber pNum = PeanoNumber.fromInteger(2);
		System.Console.WriteLine("PeanoNumber set to 2");    
		pNum.print();
		System.Console.WriteLine("");
		
		PeanoNumber tNum = PeanoNumber.fromInteger(1);
		System.Console.WriteLine("PeanoNumber set to 1");
		tNum.print();
		System.Console.WriteLine("");
		System.Console.WriteLine("add 2 and 1");
		PeanoNumber total = pNum + tNum;
		total.print();
		System.Console.WriteLine("");
	}
		
	
}



}