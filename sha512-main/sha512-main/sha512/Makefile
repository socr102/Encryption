CC=gcc
CFLAGS=-I.
DEPS=sha512.h

%.o: %.c $(DEPS)
	$(CC) -c -o $@ $< $(CFLAGS)

sha512: sha512.o
	$(CC) -o sha512 sha512.o

test:
	./sha512 input.txt | diff - expected.txt | echo "Test passed!"

