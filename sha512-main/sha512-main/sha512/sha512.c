/**
 * Program to find the hexadecimal SHA512 value of input file
 * First argument to the program should be the filename
 * Author
 * School
 * Date
 * Licence
**/

/**
 * Program to find the hexadecimal SHA512 value of input file
 * SHA-512: This algorithm comes directly from the NSA. 
 * The hash value is 512 bits. 
 * This makes SHA much safer than the other option.
**/

/**
 * Resources
 * https://csrc.nist.gov/projects/hash-functions
 * https://id.loc.gov/vocabulary/preservation/cryptographicHashFunctions/sha512
 * https://emn178.github.io/online-tools/sha512.html
**/


// Including the custom header
#include "sha512.h"

#define GRACEFUL_EXIT 0
#define NON_GRACEFUL_EXIT 0
#define NULL_POINTER NULL

int main(int argc, char const *argv[]) {

    // Required arguments (one for program name)
    // File name required
    int required_arguments = 2;
    // If file arguments are more or less, show usage
    if (argc != required_arguments) {
        printf("Error: File name/path is required.\n");
        return NON_GRACEFUL_EXIT;
    }

    // File pointer for the input file
    FILE *input_file_pointer = fopen(argv[1], "rb");
    // If the file pointer is null (file not found)
    if (input_file_pointer == NULL_POINTER) {
        printf("Error: File name/path is invalid.\n");
        return NON_GRACEFUL_EXIT;
    }

    // Preprocessing the 
    uint16_t block_count;
    uint64_t* input_string = preprocess(input_file_pointer, &block_count);

    // Buffers for SHA512 standard
    // Source: https://www.slideshare.net/sharifulr/secure-hash-algorithm-sha512
    uint64_t sha512_buffers[] = {
    0x6A09E667F3BCC908, 0xBB67AE8584CAA73B, 0x3C6EF372FE94F82B, 0xA54FF53A5F1D36F1,
    0x510E527FADE682D1, 0x9B05688C2B3E6C1F, 0x1F83D9ABFB41BD6B, 0x5BE0CD19137E2179
    };

    calculate_hash(block_count, input_string, (uint64_t*) &sha512_buffers);

    // Printing the hash value
    for (int i = 0; i < 8; i++) {
        printf("%016llx", (unsigned long long) sha512_buffers[i]);
    }
    printf("\n");
    return GRACEFUL_EXIT;
}


// Implementation of the function where the calculation of hash begins
void calculate_hash(uint16_t block_count, uint64_t* input_string, uint64_t* sha512_buffers) {

    // Buffers for SHA512 standard
    // Source: https://www.slideshare.net/sharifulr/secure-hash-algorithm-sha512
    uint64_t sha512_inits[] = {
        0x6A09E667F3BCC908, 0xBB67AE8584CAA73B, 0x3C6EF372FE94F82B, 0xA54FF53A5F1D36F1,
        0x510E527FADE682D1, 0x9B05688C2B3E6C1F, 0x1F83D9ABFB41BD6B, 0x5BE0CD19137E2179
    };

    for (int descrete_block = 0; descrete_block < block_count; descrete_block++) {

        uint64_t hash_schedule[80];
        get_wt_schedule(&input_string[descrete_block*16], hash_schedule);

        for (int round_count = 0; round_count < 80; round_count++){
            do_round(sha512_buffers, round_count, hash_schedule[round_count]);
        }

        for (int i = 0; i < 8; i++) {
            sha512_buffers[i] += sha512_inits[i];
            sha512_inits[i] = sha512_buffers[i];
        }
    }
}

// Implementation of the preprocessing function which interacts with file
// and made calculations related to the blocks
uint64_t* preprocess(FILE* input_file_pointer, uint16_t* block_count) {
    
    // First, we read the input file as passed on 
    fseek(input_file_pointer, 0, SEEK_END);
    uint16_t f_length = ftell(input_file_pointer);
    uint16_t n_flength = 0;
    if((f_length % BYTES_HEX_HASH) + 16 > BYTES_HEX_HASH){
        n_flength += BYTES_HEX_HASH;
    }
    // Then, we pad the buffer to 1024 bits
    n_flength += f_length + (BYTES_HEX_HASH - (f_length % BYTES_HEX_HASH)); 
    *block_count = n_flength/BYTES_HEX_HASH;

    rewind(input_file_pointer);

    uint64_t *input_string = (uint64_t*) malloc(n_flength);
    memset(input_string, 0, n_flength);

    // The padding begins with a 1
    ((char*) input_string)[f_length] = 0x80;

    // We set the length of the input
    ((uint64_t*) input_string)[(n_flength/sizeof(uint64_t)) -1] = endian_swap_64(f_length*8); 

    fread(input_string, 1, f_length, input_file_pointer);
    fclose(input_file_pointer);

    return input_string;
}

// Implementation of function to apply the ROT-R algorithm 
uint64_t rotr(uint64_t input_value, uint8_t amount) {
  return (input_value >> amount) | 
         (input_value << (64 - amount));
}

// Implementation of the do round algorithm for SHA512
// Source: https://en.bitcoinwiki.org/wiki/SHA-512
void do_round(uint64_t* input_string, uint8_t round_number, uint64_t word) {
  uint64_t maj = (input_string[0] & input_string[1]) ^ 
                 (input_string[0] & input_string[2]) ^ 
                 (input_string[1] & input_string[2]);

  uint64_t ch = (input_string[4] & input_string[5]) ^
                (~input_string[4] & input_string[6]);

  uint64_t suma = rotr(input_string[0], 28) ^
                  rotr(input_string[0], 34) ^
                  rotr(input_string[0], 39);

  uint64_t sume = rotr(input_string[4], 14) ^
                  rotr(input_string[4], 18) ^
                  rotr(input_string[4], 41);

  uint64_t haddthing = input_string[7] + sume + ch + hash_constants[round_number] + word;

  input_string[7] = input_string[6];
  input_string[6] = input_string[5];
  input_string[5] = input_string[4];
  input_string[4] = input_string[3] + haddthing;
  input_string[3] = input_string[2];
  input_string[2] = input_string[1];
  input_string[1] = input_string[0];
  input_string[0] = suma + maj + haddthing;
}

uint64_t endian_swap_64(uint64_t input_value) {

  uint8_t *input_hold = (uint8_t*) &input_value;

  for(int i = 0; i < sizeof(uint64_t)/2; i++) {
    uint8_t temporary_value = input_hold[i];
    input_hold[i] = input_hold[sizeof(uint64_t)-1 - i];
    input_hold[sizeof(uint64_t)-1 - i] = temporary_value;
  }

  return (uint64_t) *((uint64_t*) input_hold);
}

void get_wt_schedule(uint64_t *m_index, uint64_t *schedule_index) {
  for (int i = 0; i < 80; i++) {
    if (i < 16) {
      schedule_index[i] = endian_swap_64(m_index[i]);
      continue;
    }
    schedule_index[i] = schedule_index[i - 16] + 
                  (rotr(schedule_index[i-15], 1) ^ rotr(schedule_index[i-15], 8) ^ (schedule_index[i-15] >> 7)) +
                  schedule_index[i-7] +
                  (rotr(schedule_index[i-2], 19) ^ rotr(schedule_index[i-2], 61) ^ (schedule_index[i-2] >> 6));
  }
}