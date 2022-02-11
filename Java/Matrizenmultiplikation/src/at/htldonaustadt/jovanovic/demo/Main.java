package at.htldonaustadt.jovanovic.demo;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class Main {
    public static int[][] readFile(String filename) throws FileNotFoundException {
        Scanner scanner = new Scanner(new File(filename));
        int row = scanner.nextInt();
        int col = scanner.nextInt();
        int[][] array = new int[row][col];
        for (int row1 = 0; row1 < row; row1++) {
            for (int col1 = 0; col1 < col; col1++) {
                array[row1][col1] = scanner.nextInt();
            }
        }
        return array;
    }
    public static int[][] multiplicateMatrices(int[][]a, int[][]b){
        int row_matrix_a = a.length;
        int row_matrix_b = b.length;
        int col_matrix_b = b[0].length;
        int sum = 0;

        int [][] matrix = new int[row_matrix_a][col_matrix_b];

        for ( int row_a= 0 ; row_a < row_matrix_a ; row_a++ ){
            for ( int col_b= 0 ; col_b <col_matrix_b; col_b++)
            {
                sum=0;
                for ( int row_b= 0 ; row_b <row_matrix_b; row_b++ )
                {
                    sum +=a[row_a][row_b]*b[row_b][col_b];
                }
                matrix[row_a][col_b]=sum;
            }
        }
        return matrix;
    }
    public static void printArray(int[][]array){
        for (int[] row : array) {
            for (int column : row) {
                System.out.print(column + "\t");
            }
            System.out.println();
        }
    }
    public static void main(String[] args) throws FileNotFoundException {
        int[][] matrix_A = readFile("MatrixA.txt");
        int[][] matrix_B = readFile("MatrixB.txt");
        int[][] matrix_C = readFile("MatrixC.txt");

        int[][]product_b_c = multiplicateMatrices(matrix_B, matrix_C);
        System.out.println("B*C=");
        printArray(product_b_c);

        System.out.println();
        int[][]product_a_b = multiplicateMatrices(matrix_A, matrix_B);
        System.out.println("A*B=");
        printArray(product_a_b);

        System.out.println();
        int[][]product_a_c = multiplicateMatrices(matrix_A, matrix_C);
        System.out.println("A*C=");
        printArray(product_a_c);

    }
}