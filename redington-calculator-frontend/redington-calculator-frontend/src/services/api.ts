import axios from "axios";
import { ProbabilityRequest, ProbabilityResult } from "../types/Probability";

const api = axios.create({
  baseURL: "http://localhost:5007/api/",
});

export const calculateProbability = async (
  data: ProbabilityRequest
): Promise<ProbabilityResult> => {
  const response = await api.post<ProbabilityResult>("/calculator", data);
  return response.data;
};
