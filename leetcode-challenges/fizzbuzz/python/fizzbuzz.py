import sys

divisorOne=int(sys.argv[1])
divisorTwo=int(sys.argv[2])
upperBound=int(sys.argv[3])

if divisorOne < upperBound and divisorTwo < upperBound:
	for i in range(1,upperBound+1):
		if i%divisorOne==0 and i%divisorTwo==0:
			print "FizzBuzz"
		elif i%divisorOne==0:
			print "Fizz"
		elif i%divisorTwo==0:
			print "Buzz"
		else:
			print i
else:
	print "Args are inputed incorrectly!!!"