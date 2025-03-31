#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>

void argumentInputCheck(const char *str, int argNum, char *argNameStr);
void fizzBuzzRecursive(int divisorOne, int divisorTwo, int upperBound);

int main(int argc, char *argv[]) {

	if(argc != 4){
		printf(
		"Usage: %s \"First Divisor\" \"Second Divisor\" \"Upper_Bound\"\n",
																  argv[0]);
		printf("The Amount of Args are Incorrect.\n");
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

	fizzBuzzRecursive(divisorOne, divisorTwo, upperBound);

  return 0;
}

void argumentInputCheck(const char *str, int argNum, char *argNameStr){
		if (errno) {
			fprintf(stderr,
			"The \"%s\" in Argument %d is %s is not an Integer\n",
										 argNameStr, argNum, str);
			exit(-1);
	}
}

void fizzBuzzRecursive(int divisorOne, int divisorTwo, int upperBound){

	if(upperBound > 1){
		fizzBuzzRecursive(divisorOne, divisorTwo, (upperBound-1));
	}

	//char strOutput[sizeof(upperBound)] = "";

	if(upperBound % divisorOne != 0 && upperBound % divisorTwo != 0){
		printf("%d\n", upperBound);
	} else {
		char strOutput[10] = "";
		if(upperBound % divisorOne == 0){
			strcat(strOutput, "Fizz");
		}

		if(upperBound % divisorTwo == 0){
			strcat(strOutput, "Buzz");
		}
		printf("%s\n", strOutput);

	}


}
//5 10 104795
