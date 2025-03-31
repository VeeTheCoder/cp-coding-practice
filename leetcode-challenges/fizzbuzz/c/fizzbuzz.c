#include <stdio.h>
#include <stdlib.h>
#include <errno.h>

void argumentInputCheck(const char *str, int argNum, char *argNameStr);

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

	for(int i=1; i<=upperBound;i++){
		if(i % divisorOne == 0 && i % divisorTwo == 0){
			printf("FizzBuzz\n");
		}else if(i % divisorOne == 0){
			printf("Fizz\n");
		}else if(i % divisorTwo == 0){
			printf("Buzz\n");
		}else{
			printf("%d\n",i);
		}
	}

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
