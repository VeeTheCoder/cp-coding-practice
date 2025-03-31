import System.Environment

main = do
   [divisorOne,divisorTwo,upperBound] <- map read<$>getArgs
   mapM putStrLn (fizz upperBound divisorOne divisorTwo)

fizz :: Int -> Int -> Int -> [String]
fizz n x y = 
  map fizzbuzz [1..n] where
  fizzbuzz i =
   if i `mod` x == 0 && i `mod` y == 0
    then "FizzBuzz"
   else if i `mod` x == 0
    then "Fizz"
   else if i `mod` y == 0
    then "Buzz"
   else
    show i