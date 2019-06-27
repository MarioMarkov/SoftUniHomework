<?php
namespace CalculatorBundle\Entity;

class Calculator
{
    /**
     *  @var float
     */
    private $leftOperand;
    /**
     *  @var float
     */
    private $rightOperand;
    /**
     *  @var string
     */
    private $operator;

    /**
     * @return float
     */
    public function getLeftOperand()
    {
        return $this->leftOperand;
    }

    /**
     * @return float
     */
    public function getRightOperand()
    {
        return $this->rightOperand;
    }

    /**
     * @return string
     */
    public function getOperator()
    {
        return $this->operator;
    }

    /**
     * @param float $leftOperand
     */
    public function setLeftOperand($leftOperand)
    {
        $this->leftOperand = $leftOperand;
    }

    /**
     * @param float $rightOperand
     */
    public function setRightOperand($rightOperand)
    {
        $this->rightOperand = $rightOperand;
    }

    /**
     * @param string $operator
     */
    public function setOperator($operator)
    {
        $this->operator = $operator;
    }




}