#return the first n fibonacci numbers

def fib(n):
	#recursive function 
	#that returns the n-th element of the fibonacci sequence
	if n == 1:
		return 1
	elif n == 0:
		return 0
	else:
		return fib(n - 1) + fib(n - 2)


def fib_number():
	n = int(input("N: "))
	idx = 1
	result = 0
	while idx <= n:
		result = result * 10 + fib(idx)
		idx += 1
	print(result)

fib_number()
