#include <iostream>
using namespace std;

void argumentInputCheck(const char *str, int argNum, string argNameStr);

int main(int argc, char* argv[]){

  if(argc != 4){
    cout << "Usage: " << argv[0] <<
              " \"First Divisor\" \"Second Divisor\" \"Upper_Bound\"\n";
    cout << "The Amount of Args are Incorrect.\n";
    return(-1);
  }

  int divisorOne, divisorTwo, upperBound;
  divisorOne = divisorTwo = upperBound = 0;

  divisorOne = strtol(argv[1], NULL, 0);
	argumentInputCheck(argv[1],1, "First Divisor");
	divisorTwo = strtol(argv[2], NULL, 0);
	argumentInputCheck(argv[2],2, "Second Divisor");
	upperBound = strtol(argv[3], NULL, 0);
	argumentInputCheck(argv[3],3, "Upper Bound");

  for(int i=1; i<=upperBound;i++){
    if(i % divisorOne == 0 && i % divisorTwo == 0){
      cout << "FizzBuzz\n";
    }else if(i % divisorOne == 0){
      cout << "Fizz\n";
    }else if(i % divisorTwo == 0){
      cout << "Buzz\n";
    }else{
      cout << i << endl;
    }
  }

  return 0;
}

void argumentInputCheck(const char *str, int argNum, string argNameStr){
		if (errno) {
			cout << "The \"" << argNameStr << "\" in Argument " << argNum <<
                                " is " << str <<" is not an Integer\n";
			exit(-1);
	}
}
