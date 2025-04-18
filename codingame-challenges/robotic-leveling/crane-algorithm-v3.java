import java.util.*;
import java.io.*;

public class Player {
    public static String solve(int clawPos, int[] boxes, boolean boxInClaw) {        
        int numberOfPallets = boxes.length;
        
        int[] offsetArray = getOffsetArray(boxes, boxInClaw);
        
        // Calculate the minimum distance to each pile
        int minDistanceToEachPile = Arrays.stream(offsetArray).mapToInt(Math::abs).min().getAsInt();
        
        // Determining the action based on the minimum distance and offset
        return boxInClaw && Math.abs(clawPos - getOffsetPosition(minDistanceToEachPile, offsetArray)) <= minDistanceToEachPile ? "Remove" : "Put";
    }
    
    private static int[] getOffsetArray(int[] boxes, boolean boxInClaw) {
        // Array creation
        int numberOfPallets = boxes.length;
        return Arrays.stream(boxes).map((box -> box - (boxInClaw ? 1 : 0))).toArray();
    }
    
    private static int getOffsetPosition(int minDistance, int[] offsetArray) {
        // Determine the position
        return Arrays.stream(offsetArray).filter(offset -> Math.abs(minDistance - offset) <= minDistance).findFirst().getAsInt();
    }

    // Ignore and do not change the code below
    public static void main(String args[]) {
        Scanner in = new Scanner(System.in);
        
        // game loop
        while (true) {
            int clawPos = in.nextInt();
            boolean boxInClaw = in.nextInt() != 0;
            int stacks = in.nextInt();
            int[] boxes = new int[stacks];
            for (int i = 0; i < stacks; i++) {
                boxes[i] = in.nextInt();
            }
            
            PrintStream outStream = System.out;
            System.setOut(System.err);
            String action = solve(clawPos, boxes, boxInClaw);
            System.setOut(outStream);
            System.out.println(action);
        }
    }
}