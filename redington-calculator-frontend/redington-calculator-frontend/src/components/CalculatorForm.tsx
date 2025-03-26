import { useState } from "react";
import { calculateProbability } from "../services/api";
import { CalculationType, ProbabilityRequest } from "../types/Probability";

const CalculatorForm = () => {
  const [form, setForm] = useState<ProbabilityRequest>({
    probabilityA: 0,
    probabilityB: 0,
    calculationType: "CombinedWith",
  });

  const [result, setResult] = useState<number | null>(null);
  const [error, setError] = useState<string | null>(null);

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value } = e.target;
    setForm({
      ...form,
      [name]: name === "calculationType" ? value : parseFloat(value),
    });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    // Simple validation
    if (
      form.probabilityA < 0 ||
      form.probabilityA > 1 ||
      form.probabilityB < 0 ||
      form.probabilityB > 1
    ) {
      setError("Probabilities must be between 0 and 1.");
      return;
    }

    try {
      const response = await calculateProbability(form);
      setResult(response.result);
      setError(null);
    } catch (err) {
      setResult(null);
      setError("Something went wrong. Please check API.");
    }
  };

  return (
    <div className='container mt-5'>
      <h2 className='mb-4'>Probability Calculator</h2>
      <form onSubmit={handleSubmit} className='card p-4 shadow-sm'>
        <div className='mb-3'>
          <label className='form-label'>Probability A (0 - 1)</label>
          <input
            type='number'
            name='probabilityA'
            value={form.probabilityA}
            onChange={handleChange}
            className='form-control'
            step='0.01'
            min={0}
            max={1}
            required
          />
        </div>

        <div className='mb-3'>
          <label className='form-label'>Probability B (0 - 1)</label>
          <input
            type='number'
            name='probabilityB'
            value={form.probabilityB}
            onChange={handleChange}
            className='form-control'
            step='0.01'
            min={0}
            max={1}
            required
          />
        </div>

        <div className='mb-3'>
          <label className='form-label'>Calculation Type</label>
          <select
            name='calculationType'
            className='form-select'
            value={form.calculationType}
            onChange={handleChange}
          >
            <option value='CombinedWith'>CombinedWith</option>
            <option value='Either'>Either</option>
          </select>
        </div>

        <button type='submit' className='btn btn-primary w-100'>
          Calculate
        </button>
      </form>

      {result !== null && (
        <div className='alert alert-success mt-4'>Result: {result}</div>
      )}

      {error && <div className='alert alert-danger mt-4'>{error}</div>}
    </div>
  );
};

export default CalculatorForm;
