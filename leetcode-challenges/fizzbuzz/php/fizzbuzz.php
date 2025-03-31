$divisorOne=3;
$divisorTwo=5;
$upperBound=100;

for($i=1;$i<=100;$i++){
  if(($i%$divisorOne == 0) && ($i%$divisorTwo == 0)){
    echo ("FizzBuzz\n");
  } else if ($i%$divisorOne == 0){
    echo ("Fizz\n");
  } else if ($i%$divisorTwo == 0){
    echo ("Buzz\n");
  } else{
    echo($i."\n");
  }
}