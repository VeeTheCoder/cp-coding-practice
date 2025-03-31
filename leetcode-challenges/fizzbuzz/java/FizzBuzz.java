import java.util.*;

public class FizzBuzz{
	
	public static void main(String[] args){
			
		if(args.length != 3){
			System.out.println("The Amount of Args are Incorrect.");
			System.exit(1);
		}

		int divisorOne, divisorTwo, upperBound;
		divisorOne = divisorTwo = upperBound = 0;

		try{
			divisorOne = Integer.parseInt(args[0]);
			divisorTwo = Integer.parseInt(args[1]);
			upperBound = Integer.parseInt(args[2]);

		}catch(NumberFormatException e){
  			System.out.println("At least one of the Args are not Integers");
  			System.exit(1);
		}

		for(int i=1; i<=upperBound;i++){
			if(i % divisorOne == 0 && i % divisorTwo == 0){
				System.out.println("FizzBuzz");
			}else if(i % divisorOne == 0){
				System.out.println("Fizz");
			}else if(i % divisorTwo == 0){
				System.out.println("Buzz");
			}else{
				System.out.println(i);
			}
		}
	}
}