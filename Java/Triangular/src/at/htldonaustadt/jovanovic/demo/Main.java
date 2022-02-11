package at.htldonaustadt.jovanovic.demo;

public class Main {

    public static void main(String[] args) {
        int[][] matrix = {  { 4, 2, 5, 8, 4, 2, 4, 5 },
                            { 3, 4, 2, 6, 5, 2, 4, 6 },
                            { 2, 0, 3, 7, 2, 4, 2, 4 },
                            { 1, 1, 2, 1, 2, 4, 1, 9 },
                            { 4, 2, 6, 8, 9, 9, 9, 9 },
                            { 4, 5, 3, 5, 3, 4, 5, 6 },
                            { 1, 2, 3, 4, 5, 6, 7, 8 },
                            { 9, 8, 7, 6, 4, 3, 2, 1 },
                 };

        int [][]triangular = printTriangularMatrix(true, matrix);
        for(int[]row : matrix){
            for(int col : row){
                System.out.print(col + " ");
            }
            System.out.println();
        }
    }
    private static int[][] printTriangularMatrix(boolean righttop, int[][]matrix)
    {   int row_triangular_matrix = matrix.length;
        int col_triangular_matrix = matrix[0].length;
        int[][] triangular_matrix = matrix;

        int counter = 0;
        boolean increaseCounterLeftToRight = false;

        if(!righttop){
            counter = 1;
            increaseCounterLeftToRight = true;
        } else {
            counter = col_triangular_matrix;
        }

        int row = 0;
        if(increaseCounterLeftToRight){
            for (int col = 0; col < col_triangular_matrix; col++) {
                if(col <= counter){
                    for (int i = counter; i < triangular_matrix[row].length; i++) {
                        triangular_matrix[row][i] = 0;
                    }
                }
                counter++;
                row++;
            }
        }  /* falsch else {
            for (int col = col_triangular_matrix; col >= 0; col--) {
                if(col > counter) {
                    for (int i = counter; i >= 2 ; i--) {
                        triangular_matrix[row][i] = 0;
                    }
                }
                counter--;
                row++;
            }*/
        }

        return triangular_matrix;
     }
}
