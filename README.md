# UnityDOTSWorks

This repository, **UnityDOTSWorks**, demonstrates various approaches to coding the rotation of thousands of objects in Unity. The project focuses on comparing traditional object-oriented code with Unity's Data-Oriented Technology Stack (DOTS) and the Job System with Burst Compiler to see how each approach impacts performance.

## Unity Data-Oriented Technology Stack (DOTS)

Unity's Data-Oriented Technology Stack (DOTS) is designed to maximize performance by optimizing data layout and leveraging parallel processing. In this project, DOTS is defined and compared against traditional object-oriented programming and Unity's Job System with Burst Compiler. By observing the performance differences, you can gain insight into the benefits of DOTS over conventional coding methods.

## Scenes Overview

1. **TraditionalWay-EveryObjectWithOwnRotationScript.unity**
   - **Description**: This scene uses a traditional object-oriented approach where each object has its own rotation script. While this method is straightforward, it can become inefficient with a large number of objects due to the overhead of individual scripts.

2. **TraditionalWay-AllObjectRotationWithSingleScript.unity**
   - **Description**: In this scene, a single script manages the rotation of all objects. This reduces the overhead compared to the previous approach but still relies on traditional object-oriented programming.

3. **JobWay.unity**
   - **Description**: This scene utilizes Unity's Job System to handle object rotation in parallel. The Job System allows for more efficient use of CPU resources by distributing work across multiple threads, leading to better performance compared to the traditional approaches.

4. **DOTSWay.unity**
   - **Description**: This scene employs Unity's Data-Oriented Technology Stack (DOTS), which includes the Entity Component System (ECS), Jobs, and the Burst compiler. This approach is designed to achieve maximum performance by optimizing data layout and parallelizing tasks. You can find two systems in it the one with Jobs and the other one without job. You can find a toggle in the scene to trun of Job +ECS approach.

## How to Use

- **Manual FPS Check**: Load each scene in Unity, run the project, and manually check the FPS to compare the performance of each approach.
- **Feedback**: If you find a better approach or spot any incorrect methods, please open an issue or submit a pull request. I'm currently learning DOTS, so any feedback or suggestions for improvement are welcome.

## Future Updates

- **Code Improvements**: As I continue to learn and improve, I will work on enhancing the code and optimizing the approaches demonstrated in this repository. Stay tuned for ongoing updates.
- **Performance Videos**: I plan to upload videos showing the FPS results of all approaches.
- 
## Disclaimer

This repository is a work in progress and may contain incorrect approaches or methods. It is primarily for learning and experimenting with different coding paradigms in Unity.
