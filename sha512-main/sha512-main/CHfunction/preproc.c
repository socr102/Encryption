// https://web.microsoftstream.com/video/84fc3465-b68b-4e9d-b7be-494a15e99741
// https://web.microsoftstream.com/video/3b118cf8-ade8-4a2b-8c23-e5faca7235b3
// https://web.microsoftstream.com/video/81a21853-0f2b-4a8c-8167-435a09da7f63
// https://web.microsoftstream.com/video/15d13290-739e-4eb8-821a-bae96ca6d408


#include <stdio.h>
#include <inttypes.h>

#define W 32
#define WORD uint32_t
#define PF PRIX32
#define BYTE uint8_t

union Block {
    BYTE bytes[64];
    WORD words[16];
    uint64_t sixF[9];
};

enum Status {
    READ, PAD, PAD0, PAD1, END
};

// get next Block.
int next_block(FILE *f, union Block *B, enum Status *S, uint64_t *nobits) {
    // number of bytes read.
    size_t nobytes;

    if (*S == END) {
        return 0;
    } else if (*S == READ) {
        // try to read 64 bytes.
        nobytes = fread(B->bytes, 1, 64, f);
        // calculate the total bits read so far.
        *nobits = *nobits + (8 * nobytes);
        // enough room for padding.
        if (nobytes == 64) {
            return 1;
        } else if (nobytes <= 55) {
            // append a 1 bit (and seven 0 bits to make  full byte)
            B->bytes[nobytes] = 0x80; // In bits: 1000000
            // append enough 0 bits, leaving 64 at the end.
            while (nobytes++ < 56) {
                B->bytes[nobytes] = 0x00; // In bits: 0000000
            }
            // append length of original input.
            B->sixF[7] = *nobits;
            // last block.
            *S = END;
        } else {
            // gotten to the end of the input message.
            // not enough room in the black fo all padding.
            // append a 1 bit (and seven 0 bits to make a full byte)
            B->bytes[nobytes] = 0x80;
            // append 0 bits.
            while (nobytes++ < 64) {
                B->bytes[nobytes] = 0x00; // In bits: 0000000
            }
            // change the status to PAD
            *S = PAD;
        }
    } else if (*S == PAD) {
        nobytes = 0;
        // append 0 bits.
        while (nobytes++ < 56) {
            B->bytes[nobytes] = 0x00; // In bits: 0000000
        }
        // append num of bits as a integer.
        B->sixF[7] = *nobits;
        // change the status to END
        *S = END;
    }
    return 1;
}

int main(int argc, char *argv[]) {
    // Iterator
    int i;
    // current block.
    union Block B;
    // total number of bits read.
    uint64_t num_of_bits = 0;
    // current status of reading input,
    enum Status S = READ;
    // File pointer for reading.
    FILE *f;
    // Open file from cli for reading.
    if (!(f = fopen(argv[1], "r")) )
    {
       printf("Not able to read file");
       return 1;
    }

    // loop through the pre-processed Blocks
    while (next_block(f, &B, &S, &num_of_bits)) {
        // print the 16 32-bit words.
        for (i = 0; i < 16; i++) {
            printf("%08" PF " ", B.words[i]);
        }
        printf("\n");
    }
    // close file
    fclose(f);
    // print total number of bits read.
    printf("Total number of bits read: %lu.\n", num_of_bits);

    return 0;
}