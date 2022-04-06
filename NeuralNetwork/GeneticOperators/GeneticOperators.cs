using System;
using System.Collections.Generic;

public static class GeneticOperators
{
	public static NeuralNetwork[] Selection(NeuralNetwork[] population)
	{
		List<NeuralNetwork> pop = new List<NeuralNetwork>(population);
		pop.Sort();
		population = pop.ToArray();

		for (int i=0;i< population.Length/4; i++)
			{
				population[i] =  getBest(population[i],Utils.RandomElement(population));
			}

		return population;
	}

	public static NeuralNetwork[] CrossOver(NeuralNetwork[] population)
	{
		List<NeuralNetwork> pop = new List<NeuralNetwork>(population);
		pop.Sort();



		for (int i= 0; i< pop.Count/4; i++)
        {
			
//			population[i] = Utils.RandomElement(population).hidden[i].
			
        }
		return population;
	}

	public static NeuralNetwork[] Mutation(NeuralNetwork[] population)
	{
		for(int i=0; i< population.Length; i++)
        {
			if(Utils.RollOdds(0.01f))
            {

                NeuralNetwork random = Utils.RandomElement(population);
                for (int j = 0; j < random.hidden.Length; j++)
                {
                    HiddenNeuron hid = random.hidden[j];
                    hid.outputWeights[Utils.RandomRange(0, hid.outputWeights.Length - 1)] += Utils.RandomRange(-1f, 1f);

                }

            }
        }


		return population;
	}



	private static NeuralNetwork getBest(NeuralNetwork annA, NeuralNetwork annB)
    {
		if (annA.Fitness > annB.Fitness)
			return annA;
		else return annB;
    }

}